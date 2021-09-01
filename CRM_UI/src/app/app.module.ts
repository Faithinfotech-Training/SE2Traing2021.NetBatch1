import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { CourseComponent } from './course/course.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ManagerComponent } from './manager/manager.component';
import { HomeComponent } from './home/home.component';
import { HttpErrorInterceptor } from './shared/httpErrorInterceptorService';
import { AdminComponent } from './admin/admin.component';
import { CourseEnquiryComponent } from './course-enquiry/course-enquiry.component';
import { ResourceComponent } from './resource/resource.component';

import { ResourceEnquiryComponent } from './resource-enquiry/resource-enquiry.component';
import { ACoursesComponent } from './acourses/acourses.component';
import { EditcourseComponent } from './editcourse/editcourse.component';
import { AresourcesComponent } from './aresources/aresources.component';
import { EditresourceComponent } from './editresource/editresource.component';
import { AddcourseComponent } from './addcourse/addcourse.component';
import { AddresourceComponent } from './addresource/addresource.component';
import { AcourseenquiryComponent } from './acourseenquiry/acourseenquiry.component';
import { UpdatecenquiryComponent } from './updatecenquiry/updatecenquiry.component';
import { UpdaterenquiryComponent } from './updaterenquiry/updaterenquiry.component';
import { AresourceenquiryComponent } from './aresourceenquiry/aresourceenquiry.component';
import { InsightsComponent } from './manger/insights/insights.component';
import { InsightService } from './manger/insights/insights.service';
import { ManagerInsightsComponent } from './manager-insights/manager-insights.component';


@NgModule({
  declarations: [
    AppComponent,
    CourseComponent,
    LoginComponent,
    RegisterComponent,
    ManagerComponent,
    HomeComponent,
    AdminComponent,
    CourseEnquiryComponent,
    ResourceComponent,
    
    
    ResourceEnquiryComponent,
         ACoursesComponent,
         EditcourseComponent,
         AresourcesComponent,
         EditresourceComponent,
         AddcourseComponent,
         AddresourceComponent,
         AcourseenquiryComponent,
         UpdatecenquiryComponent,
         UpdaterenquiryComponent,
         AresourceenquiryComponent,
         InsightsComponent,
         ManagerInsightsComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [InsightService,{
    provide:HTTP_INTERCEPTORS,
    useClass:HttpErrorInterceptor,
    multi:true,
  }],
  bootstrap: [AppComponent],
  
})
export class AppModule { }
