let myDesigner;

function initializeFPD(element, json) {

  const jsonObject = JSON.parse(json);

  const appOptions = {
    productsJSON: jsonObject,
    // productsJSON: 'json/blank.json', //see JSON folder for products sorted in categories
    designsJSON: './json/designs.json', //see JSON folder for designs sorted in categories
    stageWidth: 1200,
    editorMode: false,
    smartGuides: true,
    usePrintingBoxAsBounding: true,
    //uiTheme: 'doyle',
    fonts: [
      { name: 'Helvetica' },
      { name: 'Times New Roman' },
      { name: 'Verdana' },
      { name: 'Tahoma' },
      { name: 'Trebuchet' },
      { name: 'Georgia' },
      { name: 'Courier New' },
      // {name: 'Brush Script MT'},
      { name: 'pacificoregular', url: 'fonts/pacificoregular.ttf' },
      { name: 'Arial' },
      { name: 'Lobster', url: 'fonts/Lobster.ttf' },
      { name: 'Nurom-Bold', url: 'fonts/Nurom-Bold.ttf' }
    ],
    customTextParameters: {
      colors: true,
      removable: true,
      resizable: true,
      draggable: true,
      rotatable: false,
      autoCenter: true,
      boundingBox: "Base",
      curvable: true,
      editable: true
    },
    customImageParameters: {
      draggable: true,
      removable: true,
      resizable: true,
      rotatable: false,
      colors: '#000',
      autoCenter: true,
      boundingBox: "Base"
    },
    actions: {
      'top': ['undo', 'redo'],
      'right': ['magnify-glass', 'reset-product', 'qr-code', 'manage-layers'],
      'bottom': [],
      'left': ['download', 'print', 'snap', 'preview-lightbox']
    }
  }

  const fpd = new FancyProductDesigner(document.getElementById(element), appOptions);
  myDesigner = fpd;
}

function addCustomImage(a,b,options,d) {

  if (options === null) {
    options = undefined;  // Set to undefined if it's null
  }
  //console.log(JSON.stringify(options));
  //console.log("Called Me");
  myDesigner.addCustomImage(a,b,options,d);
}

window.callOnElementSelect = (dotNetObjectRef, element) => {
  $(element).on('elementSelect', function (event,fabricObject) {
    
      if (fabricObject != null) {
        let generalProperties = {
          id: fabricObject.id,
          title: fabricObject.title,
          boundingBox: fabricObject.boundingBox,
          boundingBoxMode: fabricObject.boundingBoxMode,
          colors: fabricObject.colors,
          draggable: fabricObject.draggable,
          excludeFromExport: fabricObject.excludeFromExport,
          editable: fabricObject.editable,
          locked: fabricObject.locked,
          removable: fabricObject.removable,
          resizable: fabricObject.resizable,
          showInColorSelection: fabricObject.showInColorSelection,
          uploadZone: fabricObject.uploadZone,
          uploadZoneMovable: fabricObject.uploadZoneMovable,
          uploadZoneRemovable: fabricObject.uploadZoneRemovable,
          zChangeable: fabricObject.zChangeable,
          type: fabricObject.type,
          copyable: fabricObject.copyable,
          topped: fabricObject.topped,
          z: fabricObject.z,
          //selectable: fabricObject.selectable,
          scaleMode: fabricObject.scaleMode,
          rotatable: fabricObject.rotatable,
          widthFontSize: fabricObject.widthFontSize,
          width: fabricObject.width,
          maxFontSize: fabricObject.maxFontSize,
          maxLength: fabricObject.maxLength,
          minFontSize: fabricObject.minFontSize
        };
        let json = JSON.stringify(generalProperties);
        //DotNet.invokeMethodAsync('hive-admin-web', 'OnElementSelect', 'test');
        dotNetObjectRef.invokeMethodAsync('OnElementSelect', json)
            .then(result => {
            })
            .catch(error => {
              console.error("Error calling .NET method:", error);
            });
      }
      // else {
      //   console.log("OnElementUnSelect");
      //   dotNetObjectRef.invokeMethodAsync('OnElementUnSelect')
      //       .then(result => {
      //       })
      //       .catch(error => {
      //         console.error("Error calling .NET method:", error);
      //       });
      // }
    
  });
};

window.callSetElementParameters = (dotNetObjectRef, id, json) => {

    let elementParameters = JSON.parse(json);
    // console.log("Step 1");
    // console.log(elementParameters);
    let element = myDesigner.getElementByID(id);
    if (element!==false) {
      // console.log("Step 2");
      //console.log(element);
      myDesigner.setElementParameters(elementParameters, element);
      // console.log("Step 3");
      //let prod = myDesigner.getProduct();
      // console.log('getProduct');
      //console.log(prod);
      //myDesigner.loadProduct(prod);
      // console.log('loadProduct');
    }
};

window.getProduct = (dotNetObjectRef) => {
  // console.log('callGetProduct clicked');
  let product = myDesigner.getProduct();
  // console.log(JSON.stringify(product));
  return JSON.stringify(product);
};

//This give us the print ready data
window.getPrintOrderData = (dotNetObjectRef) => {
  //console.log('callGetProduct clicked');
  let printOrderData = myDesigner.getPrintOrderData();
  //console.log(JSON.stringify(printOrderData));
  return JSON.stringify(printOrderData);
};

window.callOnElementRemove = (dotNetObjectRef, element) => {
  $(element).on('elementRemove', function (event,elementObject) {
    {
      //console.log('elementRemove');
      dotNetObjectRef.invokeMethodAsync('OnElementRemove')
          .then(result => {
            //console.log(result);
          })
          .catch(error => {
            //console.error("Error calling .NET method:", error);
          });
    }
  });
};