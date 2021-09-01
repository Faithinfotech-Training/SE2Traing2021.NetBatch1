import { Component, OnInit } from '@angular/core';
import { CRMService } from '../shared/crm.service';
import { Validators, FormGroup, FormControl,FormBuilder } from '@angular/forms';
import {ActivatedRoute} from  '@angular/router';
import {HttpClient} from '@angular/common/http';
import { Courseenquiry } from '../shared/courseenquiry';
import { map } from 'rxjs/operators';
import { BehaviorSubject, Observable, Subject, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

const STR_TO_SEARCH ="ERROR POST"
const error = {
  "phone": [
      "Not a valid phone number"
  ],
  "testScore": [
      "The field testScore must be between 60 and 100."
  ]
}
@Component({
  selector: 'app-course-enquiry',
  templateUrl: './course-enquiry.component.html',
  styleUrls: ['./course-enquiry.component.css']
})
export class CourseEnquiryComponent implements OnInit {
  [x: string]: any;
  
  adminenquiry:any;
  courses:any;
  ageError: string;
  url="http://localhost:25083/api/CourseEnquiry/AddCourseEnquiry";
  //enquiryForm:any;

  public enquiryForm=this.formBuilder.group({
    email:['',[Validators.email,Validators.required]],
    name:['',Validators.required],
    phone:['',Validators.required],
    qualification:['',Validators.required],
    age:['',Validators.required],
    testScore:['',Validators.required],
    enquityStatus:['',Validators.required],
    enquiryDate:['',Validators.required],
    courseId:['',Validators.required]
    
  })

  // enquiryForm = new FormGroup({
  //   name: new FormControl(''),
  //   email: new FormControl(''),
  //   phone:new FormControl(''),
  //   qualification:new FormControl(''),
  //   age:new FormControl(''),
  //   testScore:new FormControl(''),
  //   enquityStatus:new FormControl(''),
  //   enquiryDate:new FormControl(''),
  //   courseId:new FormControl('')
  //   // role:['',Validators.required],
  // });

  

  constructor(private formBuilder:FormBuilder,
    private crmservice:CRMService,private router:ActivatedRoute,private httpclient:HttpClient) { }

  
  ngOnInit(): void {
    this.crmservice.getAdminEnquiry().subscribe((data)=>{
      this.adminenquiry=data;
      console.log("getAdminEnquiry=",this.adminenquiry)
    });
    
     this.crmservice.getCurrentData(this.router.snapshot.params.courseId).subscribe((data)=>
     {
       console.log("KB",this.router.snapshot.params.courseId)
      this.enquiryForm = new FormGroup({  
      name: new FormControl(''),
      email: new FormControl(''),
      phone:new FormControl(''),
      qualification:new FormControl(''),
      age:new FormControl(''),
      testScore:new FormControl(''),
      enquityStatus:new FormControl('Enquired'),
      enquiryDate:new FormControl(''),
      courseId:new FormControl(data['couresId']),
        
         // role:['',Validators.required],
       });

       
     });
    
  }

  handleError(e: Response | any) {
    console.log( e );

    const errorObj = e.error.errors;
    for (const key in errorObj) {
      if (errorObj.hasOwnProperty(key)) {
        const element = errorObj[key];

        if( 'age' === key ) {
          this.ageError = element[0];
        }
        if( 'phone' === key ){
          this.phoneError = element[0];
        }
        if( 'testScore' === key ){
          this.scoreError = element[0]
        }
        console.log( element, STR_TO_SEARCH ); 
        
      }
    }
    return throwError;
}

 

  onSubmit()
  {
    console.log("EnquiryForm");
    console.log("form data",this.enquiryForm.value)

  //   this.httpclient.post<Response>(this.url,this.enquiryForm.value)
  //         .pipe(
  //           catchError(e => this.handleError(e)), 
  //           tap(responseData => {
  //           console.log( responseData )
  // }))
  //     .subscribe()
    
//   try {
//     this.httpclient.post(this.url,this.enquiryForm.value).subscribe((data: any)=>{
//       console.log("asdasdfd",data)
//       console.log( data.status )  
//       this.enquiryForm.reset();
//  });
try {
      this.httpclient.post(this.url,this.enquiryForm.value)
      .pipe(
        catchError(e => this.handleError(e)), 
        tap(responseData => {
        console.log( responseData )
}))
  .subscribe((data: any)=>{
      console.log("asdasdfd",data)
         console.log( data.status )  
         this.enquiryForm.reset();
    });
  } catch (error) {
      console.log(error)
  }

  
  
 this.enquiryForm.reset();
//  alert("Enquiry Submited");
}
}
