from subjects import subjects
from lxml import html
import requests


def populate_courses():
    courses = []
    for subject in subjects:
        page = requests.get('http://catalog.registrar.uiowa.edu/courses/' + subject.lower() + '/')

        parsed_html = html.fromstring(page.content)
        course_numbers = parsed_html.xpath('//*[@id="sc_sccoursedescs"]/div/p/strong/a/text()')
        course_titles = parsed_html.xpath('//*[@id="sc_sccoursedescs"]/div/p/strong/text()')
        course_schedule_hours = parsed_html.xpath('//*[@id="sc_sccoursedescs"]/div/p/strong/span/text()')
        course_description = parsed_html.xpath('//*[@id="sc_sccoursedescs"]/div/p')

        for i in range(len(course_numbers)):
            courses += [[subject, course_numbers[i], str(course_titles[i]).strip(), str(course_schedule_hours[i]).split()[0], str(course_description[i].text)]]

    return courses