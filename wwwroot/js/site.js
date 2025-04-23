function downloadFile(fileName, byteArray) {
    const blob = new Blob([new Uint8Array(byteArray)], { type: 'application/octet-stream' });
    const link = document.createElement('a');
    link.href = URL.createObjectURL(blob);
    link.download = fileName;
    link.click();
}