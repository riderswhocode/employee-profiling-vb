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


CREATE TABLE if not exists EP.personal_info (
    emp_image bytea,
    emp_no INTEGER  NOT NULL,
    item_no INTEGER,
    fname CHARACTER(30),
    mname CHARACTER(30),
    lname CHARACTER(30),
    name_ext CHARACTER(3),
    birth_date DATE,
    birth_place TEXT,
    gender CHARACTER(6),
    civil_status CHARACTER(10),
    tribe CHARACTER(20),
    religion CHARACTER(50),
    citizenship CHARACTER(30),
    height REAL,
    weight REAL,
    blood_type CHARACTER(3),
    gsis_no CHARACTER(20),
    pag_ibig_no CHARACTER(20),
    philhealth_no CHARACTER(20),
    sss_no CHARACTER(20),
    tin_no CHARACTER(20),
    res_add TEXT,
    res_zipcode CHARACTER(10),
    res_telno CHARACTER(20),
    per_add TEXT,
    per_zipcode CHARACTER(10),
    per_telno CHARACTER(20),
    email_add CHARACTER(40),
    cel_no CHARACTER(20),
    person_notify_fulname CHARACTER(50),
    person_notify_relation CHARACTER(20),
    person_notify_contact CHARACTER(20),
    remarks_comments TEXT,
    CONSTRAINT PK_personal_info PRIMARY KEY (emp_no)
);

/* ---------------------------------------------------------------------- */
/* Add table "family_background"                                          */
/* ---------------------------------------------------------------------- */

CREATE TABLE if not exists EP.family_background (
    emp_no INTEGER  NOT NULL,
    spouse_fname CHARACTER(30),
    spouse_mname CHARACTER(30),
    spouse_lname CHARACTER(30),
    spouse_name_ext CHARACTER(3),
    sp_occupation CHARACTER(30),
    sp_employer_name CHARACTER(50),
    sp_employer_add TEXT,
    sp_contact CHARACTER(20),
    father_fname CHARACTER(30),
    father_mname CHARACTER(30),
    father_lname CHARACTER(30),
    father_name_ext CHARACTER(3),
    mother_fname CHARACTER(30),
    mother_mname CHARACTER(30),
    mother_lname CHARACTER(30),
    mother_name_ext CHARACTER(3),
    PRIMARY KEY (emp_no)
);

/* ---------------------------------------------------------------------- */
/* Add table "children"                                                   */
/* ---------------------------------------------------------------------- */

CREATE TABLE  if not exists EP.children (
    emp_no INTEGER  NOT NULL,
    child_id INTEGER  NOT NULL,
    fname CHARACTER(30),
    mname CHARACTER(30),
    lname CHARACTER(30),
    name_ext CHARACTER(3),
    birth_date DATE,
    CONSTRAINT PK_children PRIMARY KEY (emp_no, child_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "educational_background"                                     */
/* ---------------------------------------------------------------------- */

CREATE TABLE  if not exists EP.educational_background (
    emp_no INTEGER  NOT NULL,
    edback_id INTEGER  NOT NULL,
    level CHARACTER(30),
    school_name CHARACTER(50),
    school_add TEXT,
    degree_course CHARACTER(50),
    year_graduated INTEGER,
    highest_level_notgraduated CHARACTER(30),
    inclusive_date_from INTEGER,
    inclusive_date_to INTEGER,
    honor_received CHARACTER(50),
    CONSTRAINT PK_educational_background PRIMARY KEY (emp_no, edback_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "eligibility_info"                                           */
/* ---------------------------------------------------------------------- */

CREATE TABLE  if not exists EP.eligibility_info (
    emp_no INTEGER  NOT NULL,
    elig_id INTEGER  NOT NULL,
    name CHARACTER(30),
    rating REAL,
    exam_date DATE,
    exam_add TEXT,
    license CHARACTER(20),
    date_released DATE,
    CONSTRAINT PK_eligibility_info PRIMARY KEY (emp_no, elig_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "works_trainings"                                            */
/* ---------------------------------------------------------------------- */

CREATE TABLE  if not exists  EP.works_trainings (
    emp_no INTEGER  NOT NULL,
    work_id INTEGER  NOT NULL,
    training_work CHARACTER(50),
    organization_name CHARACTER(50),
    organization_add TEXT,
    date_from DATE,
    date_to DATE,
    hours_no INTEGER,
    work_position CHARACTER(30),
    CONSTRAINT PK_works_trainings PRIMARY KEY (emp_no, work_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "seminars"                                                   */
/* ---------------------------------------------------------------------- */

CREATE TABLE  if not exists EP.seminars (
    emp_no INTEGER  NOT NULL,
    sem_id INTEGER  NOT NULL,
    title CHARACTER(100),
    venue TEXT,
    date_from DATE,
    date_to DATE,
    hours_no INTEGER,
    sponsor CHARACTER(50),
    CONSTRAINT PK_seminars PRIMARY KEY (emp_no, sem_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "salary_grade_stepincrement"                                 */
/* ---------------------------------------------------------------------- */

CREATE TABLE  if not exists EP.salary_grade_stepincrement (
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

CREATE TABLE  if not exists EP.service_record (
    emp_no INTEGER  NOT NULL,
    servicerec_id INTEGER  NOT NULL,
    date_from DATE,
    date_to DATE,
    position_title CHARACTER(20),
    institution_name CHARACTER(50),
    salary_grade INTEGER,
    step_inc MONEY,
    monthly_salary money,
    appointment_status CHARACTER(30),
    service_type CHARACTER(30),
    CONSTRAINT PK_service_record PRIMARY KEY (emp_no, servicerec_id)
);

/* ---------------------------------------------------------------------- */
/* Add foreign key constraints                                            */
/* ---------------------------------------------------------------------- */

ALTER TABLE EP.family_background ADD CONSTRAINT personal_info_family_background 
    FOREIGN KEY (emp_no) REFERENCES personal_info (emp_no);

ALTER TABLE EP.children ADD CONSTRAINT personal_info_children 
    FOREIGN KEY (emp_no) REFERENCES personal_info (emp_no);

ALTER TABLE EP.educational_background ADD CONSTRAINT personal_info_educational_background 
    FOREIGN KEY (emp_no) REFERENCES personal_info (emp_no);

ALTER TABLE EP.eligibility_info ADD CONSTRAINT personal_info_eligibility_info 
    FOREIGN KEY (emp_no) REFERENCES personal_info (emp_no);

ALTER TABLE EP.works_trainings ADD CONSTRAINT personal_info_works_trainings 
    FOREIGN KEY (emp_no) REFERENCES personal_info (emp_no);

ALTER TABLE EP.seminars ADD CONSTRAINT personal_info_seminars 
    FOREIGN KEY (emp_no) REFERENCES personal_info (emp_no);

ALTER TABLE EP.service_record ADD CONSTRAINT personal_info_service_record 
    FOREIGN KEY (emp_no) REFERENCES personal_info (emp_no);
