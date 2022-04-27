export function JSOnDrop(dropZoneReference) {
	
	dropZoneReference.addEventListener("drop", handleDrop);
	alert("drop zone active")
	dropZoneReference.addeve
	
	function addDragClass(e) {
		e.preventDefault();
	}
	function removeDragClass(e) {
		e.preventDefault();
	
	}
	var filesDropped;
	function handleDrop(e) {
		e.preventDefault();
		filesDropped = e.dataTransfer.files
		dropZoneReference.classList.add("hover");
		console.log(filesDropped)
	}

	return 44
}

