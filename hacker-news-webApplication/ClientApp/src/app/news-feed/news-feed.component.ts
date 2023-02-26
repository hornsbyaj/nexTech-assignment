import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'news-feed',
  templateUrl: './news-feed.component.html',
})
export class NewsFeedComponent {
  public hackerNewsStories: HackerNewsStories[];
  page: number = 1;
  itemsPerPage = 5;
  totalItems: any;
  constructor(private readonly http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.http.get<HackerNewsStories[]>(this.baseUrl + 'api/HackerNewsAPI/TopStories').subscribe(result => {
      this.hackerNewsStories = result;
    },
      error => console.error(error));
  }
}

interface HackerNewsStories {
  title: string;
  by: string;
  url: string;
}
