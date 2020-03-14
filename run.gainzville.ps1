
# docker build . --file Dockerfile --tag gainzville:1

docker run --name gainzville -p 80:80 -d gainzville:1

# docker build . --file DockerfileServer --tag gainzville-server:1
docker run --name gainzville-server -p 5050:80 -d gainzville-server:1
