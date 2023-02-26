"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var testing_2 = require("@angular/router/testing");
var http_1 = require("@angular/common/http");
var news_feed_component_1 = require("./news-feed.component");
var forms_1 = require("@angular/forms");
var ngx_pagination_1 = require("ngx-pagination");
var ng2_search_filter_1 = require("ng2-search-filter");
var card_1 = require("@angular/material/card");
var testing_3 = require("@angular/common/http/testing");
var BASE_URL = "";
describe('NewsFeedComponent', function () {
    var component;
    var fixture;
    beforeEach(testing_1.async(function () {
        testing_1.TestBed.configureTestingModule({
            imports: [testing_2.RouterTestingModule, forms_1.FormsModule, ngx_pagination_1.NgxPaginationModule, ng2_search_filter_1.Ng2SearchPipeModule, card_1.MatCardModule, testing_3.HttpClientTestingModule],
            declarations: [news_feed_component_1.NewsFeedComponent],
            providers: [http_1.HttpClient, { provide: 'BASE_URL', useValue: BASE_URL }],
        }).compileComponents();
    }));
    beforeEach(function () {
        fixture = testing_1.TestBed.createComponent(news_feed_component_1.NewsFeedComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create news-feed component', function () {
        expect(component).toBeTruthy();
    });
    it('should render title in a h1 tag', testing_1.async(function () {
        fixture.detectChanges();
        var compiled = fixture.debugElement.nativeElement;
        expect(compiled.querySelector('h1').textContent).toContain('Hacker News Top Stories');
    }));
    afterEach(function () {
        document.body.removeChild(fixture.nativeElement);
    });
});
//# sourceMappingURL=news-feed.component.spec.js.map