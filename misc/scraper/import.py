from neo4j.v1 import GraphDatabase, basic_auth
from courses import populate_courses

driver = GraphDatabase.driver("bolt://localhost", auth=basic_auth("neo4j", "password"))
session = driver.session()

i = 0
for course in populate_courses():
    i += 1
    print(i)
    session.run("CREATE (a:Course {subject:'" + course[0] + "', number:'" + course[1] + "', title:\"" + str(course[2]).replace('"', r'\"') + "\", hours:'" + course[3] + "', description:\"" + str(course[4]).replace('"', r'\"') + "\"})")

result = session.run("MATCH (a:Person) WHERE a.name = 'Arthur' RETURN a.name AS name, a.title AS title")
for record in result:
    print("%s %s" % (record["title"], record["name"]))

session.close()
