/* ---------------------------------------------------------------------- */
/* Script generated with: DeZign for Databases V9.1.4                     */
/* Target DBMS:           PostgreSQL 9                                    */
/* Project file:          EMP_PROF.dez                                    */
/* Project name:                                                          */
/* Author:                                                                */
/* Script type:           Database creation script                        */
/* Created on:            2016-10-19 16:05                                */
/* ---------------------------------------------------------------------- */


/* ---------------------------------------------------------------------- */
/* Add tables                                                             */
/* ---------------------------------------------------------------------- */

/* ---------------------------------------------------------------------- */
/* Add table "personal_info"                                              */
/* ---------------------------------------------------------------------- */

CREATE TABLE if not exists personal_info (
    emp_image bytea,
    emp_no INTEGER  NOT NULL,
    item_no INTEGER,
    fname text,
    mname text,
    lname text,
    name_ext text,
    birth_date DATE,
    birth_place TEXT,
    gender text,
    civil_status text,
    tribe text,
    religion text,
    citizenship text,
    height REAL,
    weight REAL,
    blood_type text,
    gsis_no text,
    pag_ibig_no text,
    philhealth_no text,
    sss_no text,
    tin_no text,
    res_add TEXT,
    res_zipcode text,
    res_telno text,
    per_add TEXT,
    per_zipcode text,
    per_telno text,
    email_add text,
    cel_no text,
    person_notify_fulname text,
    person_notify_relation text,
    person_notify_contact text,
    remarks_comments TEXT,
    CONSTRAINT PK_personal_info PRIMARY KEY (emp_no)
);

CREATE TABLE if not exists userstable
(
  Fullname text not null,
  username text NOT NULL,
  pass text,
  userlevel text,
  allpri text,
  createpri text,
  withgrantoptionpri text
 );

CREATE TABLE  if not exists historylog (
    logno serial NOT NULL,
    Fullname text  NOT NULL,
    task text not null,
    logtime timestamp
);

CREATE table if not exists RolesTable(
username text,
field text,
selectpri text,
insertpri text,
updatepri text,
deletepri text,
truncatepri text,
withgrantoption text
);




/* ---------------------------------------------------------------------- */
/* Add table "family_background"                                          */
/* ---------------------------------------------------------------------- */

CREATE TABLE if not exists family_background (
    emp_no INTEGER  NOT NULL,
    spouse_fname text,
    spouse_mname text,
    spouse_lname text,
    spouse_name_ext text,
    sp_occupation text,
    sp_employer_name text,
    sp_employer_add TEXT,
    sp_contact text,
    father_fname text,
    father_mname text,
    father_lname text,
    father_name_ext text,
    mother_fname text,
    mother_mname text,
    mother_lname text,
    mother_name_ext text,
    PRIMARY KEY (emp_no)
);

/* ---------------------------------------------------------------------- */
/* Add table "children"                                                   */
/* ---------------------------------------------------------------------- */

CREATE TABLE  if not exists children (
    emp_no INTEGER  NOT NULL,
    child_id INTEGER  NOT NULL,
    fname text,
    mname text,
    lname text,
    name_ext text,
    birth_date DATE,
    CONSTRAINT PK_children PRIMARY KEY (emp_no, child_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "educational_background"                                     */
/* ---------------------------------------------------------------------- */

CREATE TABLE  if not exists educational_background (
    emp_no INTEGER  NOT NULL,
    edback_id INTEGER  NOT NULL,
    level text,
    school_name text,
    school_add TEXT,
    degree_course text,
    year_graduated INTEGER,
    highest_level_notgraduated text,
    inclusive_date_from Date,
    inclusive_date_to Date,
    honor_received text,
    CONSTRAINT PK_educational_background PRIMARY KEY (emp_no, edback_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "eligibility_info"                                           */
/* ---------------------------------------------------------------------- */

CREATE TABLE  if not exists eligibility_info (
    emp_no INTEGER  NOT NULL,
    elig_id INTEGER  NOT NULL,
    name text,
    rating REAL,
    exam_date DATE,
    exam_add TEXT,
    license text,
    date_released DATE,
    CONSTRAINT PK_eligibility_info PRIMARY KEY (emp_no, elig_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "works_trainings"                                            */
/* ---------------------------------------------------------------------- */

CREATE TABLE  if not exists  works_trainings (
    emp_no INTEGER  NOT NULL,
    work_id INTEGER  NOT NULL,
    training_work text,
    organization_name text,
    organization_add TEXT,
    date_from DATE,
    date_to DATE,
    hours_no INTEGER,
    work_position text,
    CONSTRAINT PK_works_trainings PRIMARY KEY (emp_no, work_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "seminars"                                                   */
/* ---------------------------------------------------------------------- */

CREATE TABLE  if not exists seminars (
    emp_no INTEGER  NOT NULL,
    sem_id INTEGER  NOT NULL,
    title text,
    venue TEXT,
    date_from DATE,
    date_to DATE,
    hours_no INTEGER,
    sponsor text,
    CONSTRAINT PK_seminars PRIMARY KEY (emp_no, sem_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "salary_grade_stepincrement"                                 */
/* ---------------------------------------------------------------------- */

CREATE TABLE  if not exists salary_grade_stepincrement (
    salary_grade INTEGER  NOT NULL,
    step1 MONEY,
    step2 MONEY,
    step3 MONEY,
    step4 MONEY,
    step5 MONEY,
    step6 MONEY,
    step7 MONEY,
    step8 MONEY,
    CONSTRAINT PK_salary_grade_stepincrement PRIMARY KEY (salary_grade)
);

/* ---------------------------------------------------------------------- */
/* Add table "service_record"                                             */
/* ---------------------------------------------------------------------- */

CREATE TABLE  if not exists service_record (
    emp_no INTEGER  NOT NULL,
    servicerec_id INTEGER  NOT NULL,
    date_from DATE,
    date_to DATE,
    position_title text,
    institution_name text,
    salary_grade INTEGER,
    step_inc MONEY,
    monthly_salary money,
    appointment_status text,
    service_type text,
    CONSTRAINT PK_service_record PRIMARY KEY (emp_no, servicerec_id)
);

/* ---------------------------------------------------------------------- */
/* Add foreign key constraints                                            */
/* ---------------------------------------------------------------------- */

ALTER TABLE family_background ADD CONSTRAINT personal_info_family_background 
    FOREIGN KEY (emp_no) REFERENCES personal_info (emp_no);

ALTER TABLE children ADD CONSTRAINT personal_info_children 
    FOREIGN KEY (emp_no) REFERENCES personal_info (emp_no);

ALTER TABLE educational_background ADD CONSTRAINT personal_info_educational_background 
    FOREIGN KEY (emp_no) REFERENCES personal_info (emp_no);

ALTER TABLE eligibility_info ADD CONSTRAINT personal_info_eligibility_info 
    FOREIGN KEY (emp_no) REFERENCES personal_info (emp_no);

ALTER TABLE works_trainings ADD CONSTRAINT personal_info_works_trainings 
    FOREIGN KEY (emp_no) REFERENCES personal_info (emp_no);

ALTER TABLE seminars ADD CONSTRAINT personal_info_seminars 
    FOREIGN KEY (emp_no) REFERENCES personal_info (emp_no);

ALTER TABLE service_record ADD CONSTRAINT personal_info_service_record 
    FOREIGN KEY (emp_no) REFERENCES personal_info (emp_no);
