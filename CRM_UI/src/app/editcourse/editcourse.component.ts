import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { CRMService } from '../shared/crm.service';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-editcourse',
  templateUrl: './editcourse.component.html',
  styleUrls: ['./editcourse.component.css']
})
export class EditcourseComponent implements OnInit {
  url="http://localhost:25083/api/Course/UpdateCourse";

  courseDetails: any = {};

  editcourseForm = new FormGroup({
    courseName: new FormControl(''),
    courseDescription: new FormControl(''),
    courseDuration:new FormControl(''),
    courseStatus:new FormControl(''),
    
    couresId:new FormControl('')
    // role:['',Validators.required],
  });

  constructor(private crmservice:CRMService,private router:ActivatedRoute,private httpclient:HttpClient) { }

  ngOnInit(): void {
    this.editcourseForm = new FormGroup({
      courseName: new FormControl(''),
      courseDescription: new FormControl(''),
      courseDuration:new FormControl(''),
      courseStatus:new FormControl(''),
      
      couresId:new FormControl('')
      // role:['',Validators.required],
    });
      // role:['',Valid
    const courseDetails = localStorage.getItem( 'course-enquiry'  );

    if( courseDetails ){
      this.courseDetails = JSON.parse( courseDetails );
      console.log( this.courseDetails );
      localStorage.removeItem( 'course-enquiry'  );
    }

    for (const key in this.courseDetails) {
      if (this.courseDetails.hasOwnProperty(key)) {
        const value = this.courseDetails[key];
        this.editcourseForm.patchValue({[key] : value });
      }
    }
  }

  onSubmit()
  {
    console.log("EnquiryForm");
    console.log("form data",this.editcourseForm.value)
    alert("Do you want to Update");
     this.httpclient.put(this.url, JSON.stringify( this.editcourseForm.value ), {
       headers: {
        'Content-Type': 'application/json'
       }
     }).subscribe((data)=>{
       console.log("asdasdfd",data)  
       alert("Do you want to Update");
  });
  }
}
