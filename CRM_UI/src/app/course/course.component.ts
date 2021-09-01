import { Component, OnInit } from '@angular/core';
import { CRMService } from '../shared/crm.service';
import { InsightService } from '../manger/insights/insights.service';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {
  courses:any;
  adminenquiry:any;

  constructor(private crmservice:CRMService,private insight:InsightService) { }

  ngOnInit(): void {
    this.insight.Visited("Courses").subscribe(
      (item) => {
        
      },
      (error) => {
        alert("PageVisits Error occured");
        console.log(error);
      }
      );
    this.crmservice.getCourses().subscribe((data)=>{
      this.courses=data;
      console.log("getCourses=",this.courses)
    });
    this.crmservice.getAdminEnquiry().subscribe((data)=>{
      this.adminenquiry=data;
      console.log("getAdminEnquiry=",this.adminenquiry)
    });
  }

}
