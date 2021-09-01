import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ManagerComponent } from './manager/manager.component';
import { AuthService } from './guards/auth.service';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { CourseComponent } from './course/course.component';
import { CourseEnquiryComponent } from './course-enquiry/course-enquiry.component';
import { ResourceComponent } from './resource/resource.component';
import { ResourceEnquiryComponent } from './resource-enquiry/resource-enquiry.component';
import { ACoursesComponent } from './acourses/acourses.component';
import { EditcourseComponent } from './editcourse/editcourse.component';
import { AresourcesComponent } from './aresources/aresources.component';
import { AddcourseComponent } from './addcourse/addcourse.component';
import { EditresourceComponent} from './editresource/editresource.component'
import { AddresourceComponent } from './addresource/addresource.component';
import { AcourseenquiryComponent } from './acourseenquiry/acourseenquiry.component';
import { UpdatecenquiryComponent } from './updatecenquiry/updatecenquiry.component';
import { AresourceenquiryComponent } from './aresourceenquiry/aresourceenquiry.component';
import { InsightsComponent } from './manger/insights/insights.component';
import { UpdaterenquiryComponent } from './updaterenquiry/updaterenquiry.component';
import { ManagerInsightsComponent } from './manager-insights/manager-insights.component';


const routes: Routes = [
  {path:"login",component:LoginComponent},
  {path:"register",component:RegisterComponent},
  {path:"manager",component:ManagerComponent,canActivate:[AuthService]},
  {path:"home",component:HomeComponent},
  {path:"course",component:CourseComponent,canActivate:[AuthService]},
  {path:"courseenquiry/:courseId",component:CourseEnquiryComponent,canActivate:[AuthService]},
  {path:"courseenquiry/:cEnquiryId",component:CourseEnquiryComponent,canActivate:[AuthService]},
  {path:"resource",component:ResourceComponent,canActivate:[AuthService]},
  {path:"resourceenquiry/:resourceId",component:ResourceEnquiryComponent},
  {path:"acourse",component:ACoursesComponent,canActivate:[AuthService]},
  {path:"acourseenquiry",component:AcourseenquiryComponent,canActivate:[AuthService]},
  {path:"aresourceenquiry",component:AresourceenquiryComponent,canActivate:[AuthService]},
  {path:"editcourse",component:EditcourseComponent,canActivate:[AuthService]},
  {path:"editcourse/:courseId",component:EditcourseComponent,canActivate:[AuthService]},
  {path:"aresource",component:AresourcesComponent,canActivate:[AuthService]},
  {path:"addcourse",component:AddcourseComponent,canActivate:[AuthService]},
  {path:"addcourse/:courseId",component:AddcourseComponent,canActivate:[AuthService]},
  {path:"editresource",component:EditresourceComponent,canActivate:[AuthService]},
  {path:"editresource/:resourceId",component:EditresourceComponent,canActivate:[AuthService]},
  {path:"addresource",component:AddresourceComponent,canActivate:[AuthService]},
  {path:"addresource/:resourceId",component:AddresourceComponent,canActivate:[AuthService]},
  {path:"updatecenquiry",component:UpdatecenquiryComponent,canActivate:[AuthService]},
  {path:"updatecenquiry/:cEnquiryId",component:AddresourceComponent,canActivate:[AuthService]},
  {path:"updaterenquiry",component:UpdaterenquiryComponent,canActivate:[AuthService]},
  {path:"insights",component:InsightsComponent,canActivate:[AuthService]},
  {path:"managerinsights",component:ManagerInsightsComponent,canActivate:[AuthService]}
  
  
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
