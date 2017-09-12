import requests
from lxml import html
import re
import json
import csv

# noinspection SpellCheckingInspection
subjects = ['ABRD', 'ACB', 'ACCT', 'ACTS', 'AERO', 'AFAM', 'AINS', 'AMCS', 'AMST', 'ANES', 'ANIM', 'ANTH', 'ARAB',
            'ARTE', 'ARTH', 'ARTS', 'ASIA', 'ASL', 'ASLE', 'ASP', 'ASTR', 'ATEP', 'BIOC', 'BIOL', 'BIOS', 'BKAT', 'BME',
            'BMED', 'BMS', 'BUS', 'CBE', 'CBH', 'CCCC', 'CCP', 'CDE', 'CEE', 'CERM', 'CHEM', 'CHIN', 'CINE', 'CL',
            'CLAS', 'CLSA', 'CLSG', 'CLSL', 'CNW', 'COMM', 'CPH', 'CRIM', 'CS', 'CSD', 'CSI', 'CTS', 'CW', 'DANC',
            'DENT', 'DERM', 'DIET', 'DPA', 'DPH', 'DRAW', 'DSGN', 'DST', 'EALL', 'ECE', 'ECON', 'EDTL', 'EES', 'EHOP',
            'EM', 'EMTP', 'ENDO', 'ENGL', 'ENGR', 'ENNM', 'ENTR', 'ENVS', 'EPID', 'EPLS', 'ESL', 'EVNT', 'FAM', 'FAMD',
            'FIN', 'FPC', 'FREN', 'FRRB', 'GENE', 'GEOG', 'GHS', 'GRAD', 'GRMN', 'GSND', 'GWSS', 'HHP', 'HIST', 'HMP',
            'HONR', 'HPAS', 'HRTS', 'IALL', 'IAP', 'IBA', 'IE', 'IGPI', 'IIEP', 'IM', 'IMMU', 'INTD', 'INTM', 'IS',
            'ITAL', 'IWP', 'IYWS', 'JMC', 'JPNS', 'KORE', 'LAS', 'LATH', 'LATS', 'LAW', 'LING', 'LLS', 'LS', 'LWAB',
            'MATH', 'MBA', 'MCB', 'MDVL', 'ME', 'MED', 'MGMT', 'MICR', 'MILS', 'MKTG', 'MPB', 'MSCI', 'MSTP', 'MTLS',
            'MUS', 'MUSM', 'NEUR', 'NSCI', 'NSG', 'NURS', 'OBG', 'OEH', 'OMFS', 'OPER', 'OPHT', 'OPRM', 'ORDN', 'ORSC',
            'ORTH', 'OSTC', 'OTO', 'OTP', 'PA', 'PATH', 'PCD', 'PCOL', 'PCP', 'PEDO', 'PEDS', 'PERF', 'PERI', 'PHAR',
            'PHIL', 'PHTO', 'PHYS', 'PNTG', 'POLI', 'PORT', 'PRNT', 'PROS', 'PSQF', 'PSY', 'PSYC', 'PTRS', 'RAD',
            'RADO', 'RCE', 'REA', 'RELS', 'RHET', 'RSCI', 'RSCT', 'RSMR', 'RSMS', 'RSNM', 'RSP', 'RSRT', 'RSTH', 'SCLP',
            'SIED', 'SLA', 'SLAV', 'SLIS', 'SOAS', 'SOC', 'SPAN', 'SPST', 'SRM', 'SSTP', 'SSW', 'STAT', 'SURG', 'SWAH',
            'TAPE', 'TBM', 'TDSN', 'THTR', 'TOX', 'TR', 'TRNS', 'UICB', 'UIUB', 'ULIB', 'URES', 'URO', 'URP', 'WLLC',
            'WRIT']

CS_courses = [1210, 2210, 2230, 2630, 2800, 2820, 3210, 3330, 3620, 3640, 3700, 3820, 3980, 3990, 4330, 4350, 4400,
              4420, 4440, 4460, 4470, 4480, 4500, 4630, 4640, 4700, 4720, 4740, 4980, 5110, 5340, 5350, 5360, 5370,
              5430, 5610, 5620, 5630, 5710, 5720, 5800, 5810, 5820, 5830, 5850, 5860, 5980, 5990]


class Department:
    """
    Represents a department at the University of Iowa
    """

    def __init__(self, DepartmentCode):
        """
        Builds a department
        :param DepartmentCode: e.g. MATH
        """
        self.Code = DepartmentCode
        self.Courses = []

    def add_course(self, course):
        self.Courses.append(course)

    def to_json(self):
        return json.dumps(self, default=lambda o: o.__dict__, indent=4)

    def to_csv(self):
        with open("C:\\Users\\harle\\Desktop\\Courses\\" + self.Code + ".csv", 'w', newline='', encoding='utf-8') as csvfile:
            writer = csv.writer(csvfile)

            writer.writerow(["Subject", "Number", "Name", "Description", "Hours", "Offered", "Prerequisites",
                            "Corequisites", "Requirements", "Recommendations", "GE", "SameAs"])

            for course in self.Courses:
                writer.writerow([None if course.Subject is None else course.Subject,
                                None if course.Number is None else course.Number,
                                None if course.Name is None else course.Name,
                                None if course.Description is None else course.Description,
                                None if course.Hours is None else course.Hours,
                                None if course.Offered is None else course.Offered,
                                None if course.Prerequisites is None else course.Prerequisites,
                                None if course.Corequisites is None else course.Corequisites,
                                None if course.Requirements is None else course.Requirements,
                                None if course.Recommendations is None else course.Recommendations,
                                None if course.GE is None else course.GE,
                                None if course.SameAs is None else course.SameAs])


class Course:
    """
    Represents a course at the University of Iowa
    """

    def __init__(self, raw_course):
        """
        Builds a course object from an lxml.html.HtmlElement object representing a course
        :param raw_course: an lxml.html.HtmlElement object of a course
        """
        self.Subject = None
        self.Number = None
        self.Name = None
        self.Description = None
        self.Hours = None

        # optional sections
        self.Offered = None
        self.Prerequisites = None
        self.Corequisites = None
        self.Requirements = None
        self.Recommendations = None
        self.GE = None
        self.SameAs = None

        course_str_list = str(html.tostring(raw_course)).replace('>', '<').split('<')

        self.Name = course_str_list[10][2:]
        self.Subject = course_str_list[8].split(':')[0]
        self.Number = course_str_list[8].split(':')[1]
        self.Hours = course_str_list[12]
        self.Description = str(html.tostring(raw_course)).split('courseblockdesc">')[1].split('</p>')[0].split('\\n')[0]

        # remove anchor tags, leaving contents
        self.Description = re.sub(r'<(a|/a).*?>', "", self.Description)

        # Remove emphasis tags, replacing with asterisks
        self.Description = re.sub(r'<(em|/em).*?>', "*", self.Description)

        # Remove i
        self.Description = re.sub(r'<(i|/i).*?>', "\'", self.Description)

        # replacing &#<ascii>; constructs with their unicode equivalent
        self.Description = re.sub(r'&#(.*?);', chr(int()), self.Description)

        # Replace ampersands
        self.Description = self.Description.replace('&amp;', '&')

        # Replace ampersands
        self.Description = self.Description.replace("\\'", "'")

        # Remove span
        self.Description = re.sub(r'<(span|/span).*?>', "\'", self.Description)

        if 'Same as ' in self.Description:
            l = self.Description.split('Same as ')
            self.Description = l[0]
            self.SameAs = l[1]
        if 'GE: ' in self.Description:
            l = self.Description.split('GE: ')
            self.Description = l[0]
            self.GE = l[1]
        if 'Recommendations: ' in self.Description:
            l = self.Description.split('Recommendations: ')
            self.Description = l[0]
            self.Recommendations = l[1]
        if 'Requirements: ' in self.Description:
            l = self.Description.split('Requirements: ')
            self.Description = l[0]
            self.Requirements = l[1]
        if 'Corequisites: ' in self.Description:
            l = self.Description.split('Corequisites: ')
            self.Description = l[0]
            self.Corequisites = l[1]
        if 'Prerequisites: ' in self.Description:
            l = self.Description.split('Prerequisites: ')
            self.Description = l[0]
            self.Prerequisites = l[1]
        if 'Offered ' in self.Description:
            l = self.Description.split('Offered ')
            self.Description = l[0]
            self.Offered = l[1]

        # trim whitespace of required values
        self.Subject = self.Subject.strip()
        self.Number = self.Number.strip()
        self.Name = self.Name.strip()
        self.Description = self.Description.strip()
        self.Hours = self.Hours.strip()

        # trim whitespace of optional values
        if self.Offered is not None:
            self.Offered = self.Offered.strip()
        if self.Prerequisites is not None:
            self.Prerequisites = self.Prerequisites.strip()
        if self.Corequisites is not None:
            self.Corequisites = self.Corequisites.strip()
        if self.Requirements is not None:
            self.Requirements = self.Requirements.strip()
        if self.Recommendations is not None:
            self.Recommendations = self.Recommendations.strip()
        if self.GE is not None:
            self.GE = self.GE.strip()
        if self.SameAs is not None:
            self.SameAs = self.SameAs.strip()

    def to_json(self):
        return json.dumps(self, default=lambda o: o.__dict__, indent=4)

    def to_tuple(self):
        return ("None" if self.Subject is None else self.Subject,
                "None" if self.Number is None else self.Number,
                "None" if self.Name is None else self.Name,
                "None" if self.Description is None else self.Description,
                "None" if self.Hours is None else self.Hours,
                # optional
                "None" if self.Offered is None else self.Offered,
                "None" if self.Prerequisites is None else self.Prerequisites,
                "None" if self.Corequisites is None else self.Corequisites,
                "None" if self.Requirements is None else self.Requirements,
                "None" if self.Recommendations is None else self.Recommendations,
                "None" if self.GE is None else self.GE,
                "None" if self.SameAs is None else self.SameAs
                )

    def __str__(self):
        out = self.Subject + ':' + self.Number + ' ' + self.Name + ' (' + self.Hours + ')\n |  Desc: ' + \
              self.Description
        if self.Offered:
            out += '\n | Offer: ' + self.Offered
        if self.Prerequisites:
            out += '\n |Prereq: ' + self.Prerequisites
        if self.Corequisites:
            out += '\n | Coreq: ' + self.Corequisites
        if self.Requirements:
            out += '\n |   Req: ' + self.Requirements
        if self.Recommendations:
            out += '\n | Recom: ' + self.Recommendations
        if self.GE:
            out += '\n |    GE: ' + self.GE
        if self.SameAs:
            out += '\n |SameAs: ' + self.SameAs
        return out

    def to_excel_insert_line(self):
        out = self.Subject + '}' + self.Number + '}' + self.Name + '}' + self.Hours + '}' + self.Description \
              + '}' + str(self.Offered) + '}' + str(self.Prerequisites) + '}' + str(self.Corequisites) + '}' + \
              str(self.Requirements) + '}' + str(self.Recommendations) + '}' + str(self.GE) + '}' + str(self.SameAs)
        return out

    def to_database_insert_line(self):
        def escape(str):
            return str.replace("'", "''").replace("\"", "''")

        return ("INSERT INTO [dbo].[Courses] ([Subject],[Number],[Name],[Description],[Hours],[Offered],[Prerequisites]" \
                + ",[Corequisites],[Requirements],[Recommendations],[GE],[SameAs]) VALUES " + str(
            ('None' if self.Subject is None else escape(self.Subject),
             'None' if self.Number is None else escape(self.Number),
             'None' if self.Name is None else escape(self.Name),
             'None' if self.Description is None else escape(self.Description),
             'None' if self.Hours is None else escape(self.Hours),
             # optional
             'None' if self.Offered is None else escape(self.Offered),
             'None' if self.Prerequisites is None else escape(self.Prerequisites),
             'None' if self.Corequisites is None else escape(self.Corequisites),
             'None' if self.Requirements is None else escape(self.Requirements),
             'None' if self.Recommendations is None else escape(self.Recommendations),
             'None' if self.GE is None else escape(self.GE),
             'None' if self.SameAs is None else escape(self.SameAs)
             ))).replace("\"", "'")


def populate_courses_json():
    for subject in subjects:
        department = Department(subject)
        page = requests.get('http://catalog.registrar.uiowa.edu/courses/' + subject.lower() + '/')
        parsed_html = html.fromstring(page.content)
        raw_courses = parsed_html.xpath('//*[@class="sc_sccoursedescs"]/div')

        for raw_course in raw_courses:
            course = Course(raw_course)
            department.add_course(course)

        f = open("C:\\Users\\harle\\Desktop\\Courses\\" + subject + ".json", 'w')
        json.dump(department, f, default=lambda o: o.__dict__, indent=4)


def populate_courses_csv():
    for subject in subjects:
        department = Department(subject)
        page = requests.get('http://catalog.registrar.uiowa.edu/courses/' + subject.lower() + '/')
        parsed_html = html.fromstring(page.content)
        raw_courses = parsed_html.xpath('//*[@class="sc_sccoursedescs"]/div')

        for raw_course in raw_courses:
            course = Course(raw_course)
            department.add_course(course)

        department.to_csv()


def count_column_sizes():
    largest = {"Name": 0,
               "Description": 0,
               "Hours": 0,
               "Offered": 0,
               "Prerequisites": 0,
               "Corequisites": 0,
               "Requirements": 0,
               "Recommendations": 0,
               "GE": 0,
               "SameAs": 0}

    for subject in subjects:
        department = Department(subject)
        page = requests.get('http://catalog.registrar.uiowa.edu/courses/' + subject.lower() + '/')
        parsed_html = html.fromstring(page.content)
        raw_courses = parsed_html.xpath('//*[@class="sc_sccoursedescs"]/div')

        for raw_course in raw_courses:
            course = Course(raw_course)

            if len(course.Name) > largest["Name"]:
                largest["Name"] = len(course.Name)
            if len(course.Description) > largest["Description"]:
                largest["Description"] = len(course.Description)
            if len(course.Hours) > largest["Hours"]:
                largest["Hours"] = len(course.Hours)
            if course.Offered is not None:
                if len(course.Offered) > largest["Offered"]:
                    largest["Offered"] = len(course.Offered)
            if course.Prerequisites is not None:
                if len(course.Prerequisites) > largest["Prerequisites"]:
                    largest["Prerequisites"] = len(course.Prerequisites)
            if course.Corequisites is not None:
                if len(course.Corequisites) > largest["Corequisites"]:
                    largest["Corequisites"] = len(course.Corequisites)
            if course.Requirements is not None:
                if len(course.Requirements) > largest["Requirements"]:
                    largest["Requirements"] = len(course.Requirements)
            if course.Recommendations is not None:
                if len(course.Recommendations) > largest["Recommendations"]:
                    largest["Recommendations"] = len(course.Recommendations)
            if course.GE is not None:
                if len(course.GE) > largest["GE"]:
                    largest["GE"] = len(course.GE)
            if course.SameAs is not None:
                if len(course.SameAs) > largest["SameAs"]:
                    largest["SameAs"] = len(course.SameAs)

            department.add_course(course)
    return (largest)


populate_courses_json()
