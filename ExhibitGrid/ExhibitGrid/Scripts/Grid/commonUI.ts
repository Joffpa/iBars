

module commonUI {
    var webRoot;

    export function setWebRoot(root: string) {
        webRoot = root;
    }

    export function getWebRoot():string {
        return webRoot;
    }

}