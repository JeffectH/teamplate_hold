const isMobileDevice = /Android|webOS|iPhone|iPad|iPod|BlackBerry|BB|PlayBook|IEMobile|Windows Phone|Kindle|Silk|Opera Mini/i.test(navigator.userAgent);

const settings = {
  dataUrl: "Build/a34870cb8ee73a12ea6de659c76d7cdf.data.unityweb",
  frameworkUrl: "Build/baaa9c83722d9d2ba38e125279406340.framework.js.unityweb",
  codeUrl: "Build/c0edb2fc9811ec030e19f26ce05f540e.wasm.unityweb",
  streamingAssetsUrl: "StreamingAssets",
  companyName: "DefaultCompany",
  productName: "teamplate_hold",
  productVersion: "1.0.2",
  matchWebGLToCanvasSize: true,
  devicePixelRatio: !isMobileDevice ? 2 : 1.6,
};

const progressBar = document.querySelector("#progress-bar");

// Функция для получения базового URL и строки запроса из URL
function getBaseUrlAndQueryString() {
  // Получаем полный URL
  var url = window.location.href;

  // Ищем позицию знака ?
  var queryStart = url.indexOf("?");

  // Если знак ? найден
  if (queryStart !== -1) {
    return {
      baseUrl: url.substring(0, queryStart),
      queryString: url.substring(queryStart + 1)
    };
  }

  // Если знака ? нет, возвращаем весь URL как baseUrl и пустую строку для queryString
  return {
    baseUrl: url,
    queryString: ""
  };
}

// Создание Unity инстанса с передачей строки запроса
createUnityInstance(document.querySelector("#unity-canvas"), settings, (progress) => {
  progressBar.style.right = 100 * (1 - progress) + "%";
}).then((unityInstance) => {
  // Получаем базовый URL и строку запроса
  var { baseUrl, queryString } = getBaseUrlAndQueryString();

  // Заменяем window.location.href на базовый URL для корректной загрузки
  window.history.replaceState({}, document.title, baseUrl);

  // Передаем строку запроса в Unity WebGL
  if (queryString) {
    unityInstance.SendMessage('WebManager', 'HandleQueryString', queryString);
  }

  progressBar.style.display = "none";
}).catch((message) => {
  alert(message);
});