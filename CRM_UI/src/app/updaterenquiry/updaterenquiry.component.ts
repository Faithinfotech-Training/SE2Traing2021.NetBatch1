import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { CRMService } from '../shared/crm.service';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-updaterenquiry',
  templateUrl: './updaterenquiry.component.html',
  styleUrls: ['./updaterenquiry.component.css']
})
export class UpdaterenquiryComponent implements OnInit {
  url="http://localhost:25083/api/ResourceEnquiry/UpdateResouceEnquiry";
  @Input() enquiry: any;
  @Input() showModal: any;
  


  enquiryForm1 = new FormGroup({
    name: new FormControl('hbghj'),
    email: new FormControl('dfdsf'),
    phone:new FormControl('788'),   
    resEnquiryStatus:new FormControl(''),
    enquiryDate:new FormControl('2021-08-30'),
    resourceId:new FormControl('1'),
    rEnquiryId:new FormControl('')
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
          this.enquiryForm1.patchValue({ [ key ]: value })
        }
      }

    }
    this.crmservice.getCurrentData3(this.router.snapshot.params.rEnquiryId).subscribe((data)=>
     {
       console.log("KB",this.router.snapshot.params.resourceId)
      this.enquiryForm1 = new FormGroup({  
        name: new FormControl('hbghj'),
        email: new FormControl('dfdsf'),
        phone:new FormControl('788'),   
        resEnquiryStatus:new FormControl(''),
        enquiryDate:new FormControl('2021-08-30'),
        resourceId:new FormControl('1'),
        rEnquiryId:new FormControl('')
        
         // role:['',Validators.required],
       });
  });
  }

  onSubmit()
  {
    console.log("EnquiryForm");
    console.log("form data",this.enquiryForm1.value)
    
     this.httpclient.put(this.url,this.enquiryForm1.value).subscribe((data)=>{
       console.log("asdasdfd",data)  
  });
}

}
