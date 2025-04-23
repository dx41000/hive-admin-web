window.canvasHelper = {
  // Existing function to draw image with rectangle (scaling logic included)
  drawImageWithRectangle: function (
      canvas, imageBytes, 
      baseArtworkLeft, baseArtworkTop, outputWidth, outputHeight,
      printBoxLeft, printBoxTop, printBoxWidth, printBoxHeight) {
    console.log("drawImageWithRectangle");

    var ctx = canvas.getContext("2d");
    var ctx2 = canvas.getContext("2d");
    var blob = new Blob([imageBytes]); // Convert byte array to Blob

   return createImageBitmap(blob).then((image) => {
      var maxWidth = 800;
      var scaleX = 1;
      var scaleY = 1;

      if (image.width > maxWidth) {
        scaleX = maxWidth / image.width;
        scaleY = scaleX; // Maintain aspect ratio
      }

      canvas.width = image.width * scaleX;
      canvas.height = image.height * scaleY;
      canvas.scaleX = scaleX;
      canvas.scaleY = scaleY;

      ctx.clearRect(0, 0, canvas.width, canvas.height);
      ctx.drawImage(image, 0, 0, image.width * scaleX, image.height * scaleY);
      ctx.fillStyle = "rgba(255, 0, 0, 0.5)";
      ctx.fillRect(baseArtworkLeft * scaleX, baseArtworkTop * scaleY, outputWidth * scaleX, outputHeight * scaleY);
      ctx2.fillStyle = "rgba(0, 255, 255, 0.5)";
      ctx2.fillRect(printBoxLeft * scaleX, printBoxTop * scaleY, printBoxWidth * scaleX, printBoxHeight * scaleY);
      // Store scale factors and original rectangle

      canvas.originalRect = { x: baseArtworkLeft, y: baseArtworkTop, width: outputWidth, height: outputHeight }; // Store original rectangle values
      canvas.originalImageSize = { width: image.width * scaleX, height: image.height * scaleY, scaleX: canvas.scaleX, scaleY: canvas.scaleY }; // Store original image size
      console.log("value a");
      console.log(canvas.width);
      console.log(canvas.height);
      console.log(canvas.scaleX);
      console.log(canvas.scaleY);

      return  canvas.originalImageSize;


    });
  },

  // Function to save the image at the original resolution with rectangle
  saveImageAtOriginalResolution: function (canvas, imageBytes) {
    console.log("saveImageAtOriginalResolution");

    var ctx = canvas.getContext("2d");
    var blob = new Blob([imageBytes], { type: "image/png" });

    createImageBitmap(blob).then((image) => {
      // Reset canvas size to original image dimensions (no scaling)
      canvas.width = image.width;
      canvas.height = image.height;

      var scaleX = 1;
      var scaleY = 1;
      if (image.width > maxWidth) {
        scaleX = maxWidth / image.width;
        scaleY = scaleX; // Maintain aspect ratio
      }
      canvas.scaleX = scaleX;
      canvas.scaleY = scaleY;


      console.log("value b");
      console.log(canvas.width);
      console.log(canvas.height);
      console.log(canvas.scaleX);
      console.log(canvas.scaleY);


      // Draw the image at original size (without scaling)
      ctx.clearRect(0, 0, canvas.width, canvas.height);
      ctx.drawImage(image, 0, 0);



      // Retrieve original rectangle and draw it at original coordinates and size
      var rect = canvas.originalRect || { x: 0, y: 0, width: 0, height: 0 };
      ctx.fillStyle = "rgba(255, 0, 0, 0.5)"; // Semi-transparent red
      ctx.fillRect(rect.x, rect.y, rect.width, rect.height);

      // Save the image at original resolution as a data URL (base64-encoded)
      var dataUrl = canvas.toDataURL("image/png");

      // Trigger download
      var a = document.createElement("a");
      a.href = dataUrl;
      a.download = "image_with_rectangle.png"; // File name for download
      a.click(); // Trigger the download

      this.returnToScaledState(canvas, imageBytes);
    });
  },

  // Function to return to the scaled state after saving
  returnToScaledState: function (canvas, imageBytes) {
    console.log("returnToScaledState");

    var ctx = canvas.getContext("2d");
    var blob = new Blob([imageBytes], { type: "image/png" });

    createImageBitmap(blob).then((image) => {
      var scaleX = canvas.scaleX || 1;
      var scaleY = canvas.scaleY || 1;
      var originalRect = canvas.originalRect || { x: 0, y: 0, width: 0, height: 0 };

      // Resize the canvas back to the scaled size
      canvas.width = image.width * scaleX;
      canvas.height = image.height * scaleY;
      canvas.scaleX = scaleX;
      canvas.scaleY = scaleY;

      console.log("value c");
      console.log(canvas.width);
      console.log(canvas.height);
      console.log(canvas.scaleX);
      console.log(canvas.scaleY);

      // Redraw the image at the scaled size
      ctx.clearRect(0, 0, canvas.width, canvas.height);
      ctx.drawImage(image, 0, 0, image.width * scaleX, image.height * scaleY);

      // Redraw the rectangle with the scaled coordinates and size
      ctx.fillStyle = "rgba(255, 0, 0, 0.5)";
      ctx.fillRect(originalRect.x * scaleX, originalRect.y * scaleY, originalRect.width * scaleX, originalRect.height * scaleY);
    });
  },
  clearCanvas: function (canvas) {
    console.log("clearCanvas");
    var ctx = canvas.getContext("2d");
    ctx.clearRect(0, 0, canvas.width, canvas.height); // Clears the entire canvas
  },
  getCanvasHeight: function (canvas) {
    return canvas.height;
  },
  getCanvasWidth: function (canvas) {
    return canvas.width;
  },
  getScaleX: function (canvas) {
    return canvas.scaleX;
  },
  getScaleY: function (canvas) {
    return canvas.scaleY;
  }
};
