let dotNetRef;


function setupDotNetRef(ref) {
    dotNetRef = ref;
}

window.initializePostMessageHandler = () => {
    let payload = [];
    
    window.addEventListener("message", async function (event) {
        if (event.origin !== "https://localhost:7183" &&
        event.origin !== "http://hive-core-alb-production-965068177.eu-west-2.elb.amazonaws.com:49160") {
            console.log("Received message from untrusted origin:", event.origin);
            return;
        }

        if (event.data.action === "returnElements") {
            payload = event.data.payload;
            payload.forEach(element => {
                addTextbox(element.id, element.text);
            });
            returnElements();
        }

        if (event.data.action === "returnProductAndPrintOrderData") {
            callBlazorMethod(event.data.payload);
        }
        
        if (event.data.action === "returnPrintOrderData") {
            event.data.payload.custom_images = [];

            const dataPayload = event.data.payload;

            fetch('https://localhost:7026/api/shopify/proxy/saveprintfile/', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(dataPayload),
            })
                .then(response => response.json())
                .then(responseData => {
                    document.getElementById('txtPrintRequestId').textContent = responseData.data.payload.printServiceRequestId;
                    document.getElementById(data.formid).submit();
                })
                .catch(error => {
                    console.log('Error:', error);
                });
        }

        if (event.data.action === "updateElementComplete") {
            console.log("updateElementComplete");
            await getProductAndPrintOrderData();
        };
    });

    async function getProductAndPrintOrderData() {
        document.getElementById("myIframe").contentWindow.postMessage({ action: "getProductAndPrintOrderData" }, "*");
    }
    
    function callBlazorMethod(payload) {
        try {
            dotNetRef.invokeMethodAsync('ReturnProductAndPrintOrderData', JSON.stringify(payload))
                .then(result => {
         
                })
                .catch(error => {
                    console.error('Error calling method:', error);
                });
        }
        catch (error) {
            console.error('Error calling Blazor function:', error);
        }
    }
    
    function addTextbox(labelText, textboxText) {
        const container = document.getElementById('elements');
        const wrapperDiv = document.createElement('div');
        const label = document.createElement('label');
        label.textContent = labelText + ': ';
        const newTextbox = document.createElement('input');
        newTextbox.type = 'text';
        newTextbox.value = textboxText;
        newTextbox.id = 'textbox_' + new Date().getTime();
        label.setAttribute('for', newTextbox.id);
        newTextbox.placeholder = 'Enter text here';
        wrapperDiv.appendChild(label);
        wrapperDiv.appendChild(newTextbox);
        container.appendChild(wrapperDiv);
        container.appendChild(document.createElement('br'));
    }

    function returnElements() {
        var iframe = document.getElementById("myIframe");
        let customiseHtml = '';

        for (let index = 0; index < payload.length; index++) {
            const element = payload[index];
            customiseHtml += GenerateTextbox(element.id, element.designerIndex, element.text);
        }

        document.getElementById('elements').innerHTML = customiseHtml;

        document.addEventListener('keyup', function (e) {
            if (e.target && e.target.id === 'txtElementUpdate') {
                var iframe = document.getElementById("myIframe");

                var value = e.target.value;
                var elementId = e.target.getAttribute("data-id");
                var designerIndex = e.target.getAttribute("data-index");

                let message = {
                    action: "updateElement",
                    payload: {
                        id: elementId,
                        text: value,
                        designerIndex: designerIndex
                    }
                };

                iframe.contentWindow.postMessage(message, "*");
            }
        });
    }

    function GenerateTextbox(id, index, value) {
        return `<input id="txtElementUpdate" name="${id}" data-id="${id}" data-index="${index}" onClick="this.setSelectionRange(0, this.value.length)" type="text" value="${value}" /> </br></br>`;
    }
};

window.postToIframe = (action, payload) => {
    const iframe = document.getElementById("myIframe");
    const message = { action: action, payload: payload };
    iframe.contentWindow.postMessage(message, "*");
};

function resizeIframe(iframeId, width, height) {
    const iframe = document.getElementById(iframeId);
    if (iframe) {
        iframe.style.width = width + "px";
        iframe.style.height = height + "px";
    }
}