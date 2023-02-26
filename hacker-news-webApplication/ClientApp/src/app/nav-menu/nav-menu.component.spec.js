"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var testing_2 = require("@angular/router/testing");
var nav_menu_component_1 = require("./nav-menu.component");
describe('NavMenuComponent', function () {
    var component;
    var fixture;
    beforeEach(testing_1.async(function () {
        testing_1.TestBed.configureTestingModule({
            imports: [testing_2.RouterTestingModule],
            declarations: [nav_menu_component_1.NavMenuComponent],
        }).compileComponents();
    }));
    beforeEach(function () {
        fixture = testing_1.TestBed.createComponent(nav_menu_component_1.NavMenuComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', function () {
        expect(component).toBeTruthy();
    });
    it('testing nav menu', function () {
        expect(component.isExpanded == false);
    });
    afterEach(function () {
        document.body.removeChild(fixture.nativeElement);
    });
});
//# sourceMappingURL=nav-menu.component.spec.js.map