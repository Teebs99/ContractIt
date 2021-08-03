# ContractNow

## Overview

This project is designed to be a service to connect home owners and contractors. We took Angies List as the inspiration for this project. It is designed to have the user (the person looking for someone to do work) post job's and allow contractors to bid on them, or allow for the user to search for contractors to contact specifically. 


### API Requests

#### Job
`POST api/Job` In order to create a job posting there are a few things that we need.  
1. Title - This is a string used to briefly describe the work  
1. Description - This is a string that further clarifies the scope of the work needed by the contractor  
1. Phone Number - A string that should allow the contractor to call the user who posted the job  
1. Address - The address that the work will be done at as a string  
1. AuthorId - This is handled on the backend when the user registers for the app   
1. Categoryid - This assigns the Job to a specific category. This is required and the category must exist before a job can be posted  

`GET api/Job` A plain get request will return a list of all jobs posted by the user. If this list is empty it will return a 404.

`GET api/Job/{id}` A GET request with an id will search for the job posted by the user with that id. If none exist it will return a 404

`GET api/Job?CategoryId={CategoryId}` This GET request is designed to return a list of jobs posted by the user that share the same category. If none are found then it will return a 404.

`PUT api/Job` A PUT request requires the same information as the POST request and is used to update the job posting. All information is required.

`DELETE api/Job/{id}` This deletes the job from the database
#### Contractor
#### Category
