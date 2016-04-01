"use strict";
var TemplateService = (function () {
    function TemplateService() {
    }
    TemplateService.prototype.getTemplate = function (gridCode) {
        console.log("template: " + gridCode);
        return "<tr> one dfsfgdsfg dfg</tr>";
    };
    return TemplateService;
}());
exports.TemplateService = TemplateService;
//# sourceMappingURL=eas-template.service.js.map