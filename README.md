#### Author
Kyungyoon Kim   &   Daniel Pak

#### Date
Sept 24th, 2020

#### Course
CS 4540, University of Utah, School of Computing

#### Copyright
CS 4540, Kyungyoon Kim and Daniel Pak - This work may not be copied for use in Academic Coursework.


#### Github Page
https://github.com/uofu-cs4540-fall2020/urc-ps1-hello-web

#### Comments to Evaluators
If you find any bugs or improvements, plesae email to ruddbs5302@gmail.com.

#### Assignment Specific Write-up
Any additional feedback or write up required by the assignment.

#### Peers Helped
- None

#### Peers Consulted
- None

#### Acknowledgements
> List of any outside software/libraries/tools/sounds/images/etc. that you
> used to make your project better, but did not create yourself.

The texts and images that are used in `Opportunities` and `Detail` pages are from `UofU research opportunities website`.

#### References:
1.  UofU research opportunities website- https://our.utah.edu/opportunities/

#### H1(UI/UX choices):
  We tried to make the provided data as simplest as possible so user can find their needs easily. We limited 4 or 5 items on a single page and the user is able to track or search them by using the index and searcher box. In the Details web page, we made highlighted bullet points that users can understand what the opportunity requires and asks, and also we added contact lists such as name, department, email, and apply button that users can easily access and apply the opportunity.
  
#### H2(Bootstrap):
  One of our Goals for the front-end is making it simplest as possible. We made a menu button that organized all links(or pages) into its dropdown and user can easily access a page what they want. On the top right, we wanted to put all buttons that related to user, so when a user click their user name, it shows user's role, manage account and log out button. For home page, We used three different cards that indicates current opportunities in three different conditions such as "The most recent Opportunity", "The most popular Opportunity", and "Closing soon" so users can quickly catch what opportunities are available for them, and user can read which opportunities are in trending. In the Student Application form, we only asked essential informations to make it compact as possible but, by using text area, we asked them to introduce themselves briefly, and we put upload button to attach their resume as well.
  
Components we used:
- Navbar
- button
- jumbotron
- card
- dropdown
- select
- TextArea
- File Upload
- Checkboxes
- Tooltips

#### H4
  DB decision
  - Created extra DB tables for RequiredSkills and SearchTags but didn't build CRUD for these
  
  Image decision
  - allowed user to upload and Edit their image (by using base64 encoding)
  - If user doens't upload image, set deafult image("U" logo)
  - When user upload their image in Create or Edit page, it previews the image in the page.
  - loads the image in List and Detail page.
  
  Extra feature: added pagination in List page.
  
  
#### H5
  Authentication and Authorization
  - Well organized Authorization and Authentication allow to manage User DB effectily. At First, We limited the access to all pages and then gave proper authorizations to each       users.
 
 Overall Assignment.
 - We went through all the requirements.
 - For editing Oppotunities, we fix the name while seeding, but we are planning to add user Name in the register page so we can track users by their name and Email.
 - ###Important: Use "professor_mary@utah.edu" If you want to check the Professor User Name match the Opportunity Professor Name. The user Name is in the Opportunity list.
 - if the Professor Name doens't match to the Opportunity Professor Name, it won't go to Edit page.
 - User View/Role Change Page : we added extra User email and name column.
 - In the Menu dropbox, some pages will not be displayed depends on User Role.
 - We changed loginpartial to our Design.
 - After you logged in, when user click their Name, it shows its Role, manage Account page, and log out button.
  
