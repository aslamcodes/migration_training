## Use an official Tomcat runtime as a parent image
FROM tomcat:8.5-jdk8-openjdk

# Set the working directory to /usr/local/tomcat/webapps/
WORKDIR /usr/local/tomcat/webapps/

# Copy the WAR file or project files into the Tomcat webapps directory
COPY WebContent/ /usr/local/tomcat/webapps/ROOT/
COPY build/classes/net/javaguides/todoapp /usr/local/tomcat/webapps/ROOT/WEB-INF/classes/
COPY src/net/javaguides/todoapp /usr/local/tomcat/webapps/ROOT/WEB-INF/src/

# Expose the default Tomcat port
EXPOSE 8080

# Start Tomcat server
CMD ["catalina.sh", "run"] 
