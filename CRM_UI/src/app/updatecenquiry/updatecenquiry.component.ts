import { Component, OnInit, Input, SimpleChanges } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { CRMService } from '../shared/crm.service';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-updatecenquiry',
  templateUrl: './updatecenquiry.component.html',
  styleUrls: ['./updatecenquiry.component.css']
})
export class UpdatecenquiryComponent implements OnInit {
  url="http://localhost:25083/api/CourseEnquiry/UpdateCourseEnquiry";

  @Input() enquiry: any;
  @Input() showModal: any;
  status: 'Hello';

  enquiryForm = new FormGroup({
    name: new FormControl('hbghj'),
    email: new FormControl('dfdsf@gmail.com'),
    phone:new FormControl('7878787878'),
    qualification:new FormControl('sdf'),
    age:new FormControl('24'),
    testScore:new FormControl('70'),
    enquityStatus:new FormControl(''),
    enquiryDate:new FormControl('2021-08-30'),
    courseId:new FormControl('1'),
    cEnquiryId:new FormControl('')
    // role:['',Validators.required],
  });
  selectedEnquiry: any;

  constructor(private crmservice:CRMService,private router:ActivatedRoute,private httpclient:HttpClient) { }

  ngOnInit(): void {

    const selectedEnquiry = localStorage.getItem( 'enquiry' );

    if( selectedEnquiry ){
      this.selectedEnquiry = JSON.parse( selectedEnquiry );
      console.log( this.selectedEnquiry, "SELECT" );
      localStorage.removeItem( 'enquiry' );

      for (const key in this.selectedEnquiry) {
        if (this.selectedEnquiry.hasOwnProperty(key)) {
          const value = this.selectedEnquiry[key];
          this.enquiryForm.patchValue({ [ key ]: value })
        }
      }

    }

    this.crmservice.getCurrentData2(this.router.snapshot.params.cEnquiryId).subscribe((data)=>
     {
       console.log("KB",this.router.snapshot.params.courseId)
      this.enquiryForm = new FormGroup({  
      name: new FormControl('hjk'),
      email: new FormControl('hjk@gmail.com'),
      phone:new FormControl('7878787878'),
      qualification:new FormControl('ghj'),
      age:new FormControl('24'),
      testScore:new FormControl('70'),
      enquityStatus:new FormControl(''),
      enquiryDate:new FormControl('2021-08-30'),
      courseId:new FormControl('1'),
      cEnquiryId:new FormControl('')
        
         // role:['',Validators.required],
       });
  });
}

ngOnChanges(changes: SimpleChanges) {

  console.log( changes.showModal, 'MODAL' )

  if (changes.showModal) {

    console.log( changes.showModal, 'MODAL' )

    for (const key in this.selectedEnquiry) {
      if (this.selectedEnquiry.hasOwnProperty(key)) {
        const value = this.selectedEnquiry[key];
        this.enquiryForm.patchValue({ [ key ]: value })
      }
    }
  }
}


onSubmit()
  {
    console.log("EnquiryForm");
    console.log("Avadhut",this.enquiryForm.value)
    
     this.httpclient.put(this.url,this.enquiryForm.value).subscribe((data)=>{
       console.log("asdasdfd",data)  
  });
}
}
