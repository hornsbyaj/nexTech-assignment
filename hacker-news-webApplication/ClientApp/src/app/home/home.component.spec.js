"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var testing_2 = require("@angular/router/testing");
var home_component_1 = require("./home.component");
describe('HomeComponent', function () {
    var component;
    var fixture;
    beforeEach(testing_1.async(function () {
        testing_1.TestBed.configureTestingModule({
            imports: [testing_2.RouterTestingModule],
            declarations: [home_component_1.HomeComponent],
        }).compileComponents();
    }));
    beforeEach(function () {
        fixture = testing_1.TestBed.createComponent(home_component_1.HomeComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    afterEach(function () {
        document.body.removeChild(fixture.nativeElement);
    });
    it('should create home component', function () {
        expect(component).toBeTruthy();
    });
    it('should render title in a h1 tag', testing_1.async(function () {
        fixture.detectChanges();
        var compiled = fixture.debugElement.nativeElement;
        expect(compiled.querySelector('h1').textContent).toContain('Hello, Nextech!');
    }));
});
//# sourceMappingURL=home.component.spec.js.map