import { Component, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css']
})
export class CommentsComponent  {
  public id: any;
  public commentsArr: Array<any>[];
 
  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, private _router: Router, private route: ActivatedRoute) {

    this.route.params.subscribe(params => {
      this.id = params['id'];
    });
    this.getComments(this.id);
    
  }
  getComments(id):void {
    this.http.get("https://localhost:44379/api/CommentsData/"+this.id).subscribe((response: Response) => {
      this.commentsArr = response.json();
    });
  }
  Back() {
    this._router.navigate(['/messagelist']);
  }
}
