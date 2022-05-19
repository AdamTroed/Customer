# Customer API

A .NET Core 3.1 Restful Web Api which responsibility is Customer data, where we can retrieve, create, update and delete customer information records.

Thus far, we only support Customer Contact Information data, in route **api/contacts**.


## Deliverables

The project is set to run in linux containers.

### How to build and run:
 1. Open PowerShell
 2. Go to the root of the project
 3. Run `docker build -t customerapi .`
 4. Run `docker run -d -p 8080:80 --name myapp customerapi`
 5. All set! Confirm by writing `docker ps` which will list all containers that is up, look for IMAGE customerapi.

### Explained:
#### Build:

    docker build -t customerapi .

If we break this down a bit we see that we use `-t` to give our image a name. `customerapi` becomes the image name. Our last argument is a punctuation `.` and means current directory, it is here we say where to find the `Dockerfile`.

#### Run:

    docker run -d -p 8080:80 --name myapp customerapi
    
Let's break down the command:

-   `-d`, this simply means we run the container in the background.
-   `-p`  that means we will match an external port to an internal container port. Connect our machines port  `8080`  to the internal container port  `80`.
-   `--name`, this is us giving our container name,  `myapp`. If we don't specify a name one will otherwise be generated for us. 

Our last argument is the image name  `customerapi`.

## API endpoints

For API endpoint documentation, please use swagger until it is in place in here, swagger is shown in the root path.

