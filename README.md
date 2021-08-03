# ContractNow

## Overview

This project is designed to be a service to connect home owners and contractors. We took Angies List as the inspiration for this project. It is designed to have the user (the person looking for someone to do work) post job's and allow contractors to bid on them, or allow for the user to search for contractors to contact specifically. The project follows N-Tier file structure; It has a controller layer for the APIs, a model layer for the different data models we need, and a data layer which is what hold the layout for the database tables and finally a services layer which does all the heavy lifting on the back end for the API controllers.


### API Requests

#### Job
*`POST api/Job` In order to create a job posting there are a few things that we need.  
1. Title - This is a string used to briefly describe the work  
1. Description - This is a string that further clarifies the scope of the work needed by the contractor  
1. Phone Number - A string that should allow the contractor to call the user who posted the job  
1. Address - The address that the work will be done at as a string  
1. AuthorId - This is handled on the backend when the user registers for the app   
1. Categoryid - This assigns the Job to a specific category. This is required and the category must exist before a job can be posted  

*`GET api/Job` A plain get request will return a list of all jobs posted by the user. If this list is empty it will return an empty list.

*`GET api/Job/{id}` A GET request with an id will search for the job posted by the user with that id. If none exist it will return a 404

*`GET api/Job?CategoryId={CategoryId}` This GET request is designed to return a list of jobs posted by the user that share the same category. If none are found then it will return a 404.

*`PUT api/Job` A PUT request requires the same information as the POST request and is used to update the job posting. All information is required.

*`DELETE api/Job/{id}` This deletes the job from the database

#### Contractor
*`POST api/Contractor` In order to create a job posting there are a few things that we need.  
1. Name - This is a string of the contractors name  
1. Description - This is a string that further clarifies the scope of the work done by the contractor  
1. Phone Number - A string that should allow the contractor to be contacted during normal business hours  
1. CategoryId - The id for the category that the contractor does work within 

*`GET api/Contractor` A plain get request will return a list of all contractors posted by the user. If this list is empty it will return an empty list.

*`GET api/Contractor/{id}` A GET request with an id will search for the contractor with that id. If none exist it will return a 404

*`GET api/Contractor?CategoryId={CategoryId}` This GET request is designed to return a list of contractors that work within that category. If none are found then it will return a 404.

*`PUT api/Contractor` A PUT request requires the same information as the POST request and is used to update the contractor. All information is required.

*`DELETE api/Contractor/{id}` This deletes the contractor from the database
#### Category
*`POST api/Category` In order to create a job posting there are a few things that we need.  
1. JobType - This is an enum meant to limit the number of categories to specific lines of work.  
1. PriceRange - This is a decimal number meant to show the average price of the work that the contractor completes. 
1. Description - A string meant to further clarify the scope of the category.

*`GET api/Category` A plain get request will return a list of all categories. If this list is empty it will return an empty list.

*`GET api/Category/{id}` A GET request with an id will search for the category with that id. If none exist it will return a 404

*`PUT api/Category` A PUT request requires the same information as the POST request and is used to update the category. All information is required.

*`DELETE api/Category/{id}` This deletes the category from the database and assigns all contractors and job posting with that id = null.
