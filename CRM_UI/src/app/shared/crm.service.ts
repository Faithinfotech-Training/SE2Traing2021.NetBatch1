import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ResponseModel } from '../Models/responseModel';
import {map} from 'rxjs/operators';
import { ResponseCode } from '../enums/responseCode';
import { pipe } from 'rxjs';
import { User } from '../Models/user';
import { Constants } from '../Helper/constants';

@Injectable({
  providedIn: 'root'
})
export class CRMService {
  

  constructor(private httpclient:HttpClient) { }
  baseurl:string="http://localhost:25083/api/";

  getCourses()
  {
    return this.httpclient.get(this.baseurl+"Course/getAllCourses");


  }

  public login(email:string,password:string)
  {
    const body={
    Email:email,
    Password:password}
    return this.httpclient.post<ResponseModel>(this.baseurl+"User/Login",body);
  }

  public register(fullname:string,email:string,password:string)
  {
    const body={
    FullName:fullname,
    Email:email,
    Password:password,
    // Role:role
  }
    return this.httpclient.post<ResponseModel>(this.baseurl+"User/RegisterUser",body);
  }

  public enquiry(name:string,courseId:number)
  {
    const body={
    courseName:name,
    //email:email,
    courseId:courseId,
    // Role:role
  }
    return this.httpclient.post<ResponseModel>(this.baseurl+"CourseEnquiry/AddEnquiry",body);
  }


  public getAllUser()
  {
    let userInfo=JSON.parse(localStorage.getItem(Constants.USER_KEY));

    
    const headers=new HttpHeaders({
      'Authorization':`Bearer ${userInfo?.token}`
    });
    return this.httpclient.get<ResponseModel>(this.baseurl+"User/GetAllUsers",{headers:headers}).pipe(map(res=>{
      let userList=new Array<User>();  
      if(res.responseCode==ResponseCode.OK)
        {
          
          if(res.dateSet)
          {
            res.dateSet.map((x:User)=>{
              userList.push(new User(x.fullName,x.email,x.userName,x.role));
            })
          }
        }
        return userList;
        
    }));
  }

  getAdminEnquiry()
  {
    return this.httpclient.get(this.baseurl+"CourseEnquiry/AdminEnquiry");
    

  }
  getCurrentData(id)
  {
    return this.httpclient.get(this.baseurl+"Course/get/"+id);
  }

  getCurrentData1(id)
  {
    return this.httpclient.get(this.baseurl+"Resource/get/"+id);
  }

  getResources()
  {
    return this.httpclient.get(this.baseurl+"Resource/getAllResources");


  }

  getCourseEnquiry()
  {
    return this.httpclient.get(this.baseurl+"CourseEnquiry/getAllCourseEnquiries");
  }

  getResourseEnquiry()
  {
    return this.httpclient.get(this.baseurl+"ResourceEnquiry/getAllResourceEnquiries");
  }

  getCurrentData2(id)
  {
    return this.httpclient.get(this.baseurl+"CourseEnquiry/get/"+id);
  }

  getCurrentData3(id)
  {
    return this.httpclient.get(this.baseurl+"ResourceEnquiry/get/"+id);
  }

  
  
}