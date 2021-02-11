class FeedbackWidget {
	constructor(elementId) {
		this._elementId = elementId;
		this._element = document.getElementById(elementId);
	}
	get elementId() { //getter, set keyword voor setter methode
		return this._elementId;
	}
	show() {
		//code
		this._element.style.display = "block";
	}

	hide() {
		this._element.style.display = "none";
	}
}