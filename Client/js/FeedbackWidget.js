class FeedbackWidget {
	constructor(elementId) {
		this._elementId = elementId;
	}
	get elementId() { //getter, set keyword voor setter methode
		return this._elementId;
	}

	/**
	 * Shows an alert with the given message and type
	 * @param {String} message The message to display in the feedback
	 * @param {('success'|'fail')} type The style to apply to the feedback
	 */
	show(message, type) {
		//code
		$(`#${this._elementId}-msg`).text(message);
		$(`#${this._elementId}`).show();
		switch(type) {
			case 'success':
				$(`#${this._elementId}`).attr('class', 'alert alert-success');
				break;
			case 'fail':
				$(`#${this._elementId}`).attr('class', 'alert alert-danger');
				break;
		}
		this.log({
			message, type
		});
	}

	hide() {
		$(`#${this._elementId}`).hide();
	}

	/**
	 * Logs the alert to the local storage, with a max of 10 alerts
	 * @param {{message: String, type: 'success'|'fail'}} message 
	 */
	log(message) {
		let logs = [];
		let currStorage = localStorage.getItem('feedback_widget');
		if(!currStorage) {
			logs.push(message);
			localStorage.setItem('feedback_widget', JSON.stringify(logs));
		} else {
			logs = JSON.parse(currStorage);
			logs.push(message);
			if(logs.length > 10) 
				logs.shift();
			localStorage.setItem('feedback_widget', JSON.stringify(logs));
		}
	}

	removeLog() {
		localStorage.removeItem('feedback_widget');
	}

	history() {
		/**
		 * @type {Array<{message: String, type: 'success'|'fail'}>}
		 */
		let logs = [];
		let currStorage = localStorage.getItem('feedback_widget');
		if(!currStorage) return;
		
		logs = JSON.parse(currStorage);
		$('#history-text').html(logs.filter(msg => msg.message !== undefined).map(msg => `${msg.type} - ${msg.message}`).join('<br>'));
	}
}