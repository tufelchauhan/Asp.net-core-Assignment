import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { MessagelistComponent } from './messagelist/messagelist.component';
import { HttpModule } from '@angular/http';
import { CommentsComponent } from './comments/comments.component';
import { AddcommentComponent } from './addcomment/addcomment.component';
import { AddmessageComponent } from './addmessage/addmessage.component';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    MessagelistComponent,
    CommentsComponent,
    AddcommentComponent,
    AddmessageComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'messagelist', component: MessagelistComponent },
      { path: 'comments/:id', component: CommentsComponent },
      { path: 'addcomment/:id', component: AddcommentComponent },
      { path: 'addmessage', component: AddmessageComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
