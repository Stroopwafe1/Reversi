const Game = (function (url) {
	//Configuration and state values
	let configMap = {
		apiUrl: url
	}
	// Private function init
	const privateInit = function () {
		console.log(configMap.apiUrl);
	}

	const Reversi = (function(config) {
		let configMap = config;
		console.log("Reversi submodule", configMap);

		const init = () => {
			privateInit();
		}

		return {
			init
		}
	})(configMap);

	const Data = (function(config) {
		let configMap = config;
		console.log("Data submodule", configMap);

		const init = () => {
			privateInit();
		}

		return {
			init
		}
	})(configMap);

	const Model = (function(config) {
		let configMap = config;
		console.log("Model submodule", configMap);

		const init = () => {
			privateInit();
		}

		return {
			init
		}
	})(configMap);

	return {
		Reversi,
		Data,
		Model,
		init: privateInit
	}
})('/api/url');
