var commonUI;
(function (commonUI) {
    var webRoot;
    function setWebRoot(root) {
        webRoot = root;
    }
    commonUI.setWebRoot = setWebRoot;
    function getWebRoot() {
        return webRoot;
    }
    commonUI.getWebRoot = getWebRoot;
})(commonUI || (commonUI = {}));
//# sourceMappingURL=commonUI.js.map