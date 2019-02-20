import { Component, OnInit, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-addcomment',
  templateUrl: './addcomment.component.html',
  styleUrls: ['./addcomment.component.css']
})
export class AddcommentComponent {

  text: string = "";
  tmp: string = "";
  public id: any;
  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, private _router: Router, private route: ActivatedRoute) {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });
  }
  addComment() {
    this.tmp = this.text + "|" + this.id;
    const Http = new XMLHttpRequest();
    const url = 'https://localhost:44379/api/CommentsData/' + this.tmp;
    Http.open("POST", url);
    Http.send();
    Http.onreadystatechange = (e) => {
      this._router.navigate(['/messagelist']);
    }
  }
  Back() {
    this._router.navigate(['/messagelist']);
  }
}
