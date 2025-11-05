# Stage 1: Build the app
# Step 1: Use node image
FROM node:20 as build
# Step 2: Set working directory inside container for build
WORKDIR /app
# Step 3: Copy package files
COPY package*.json ./
# Step 4: Install dependencies
RUN npm install
# Step 5: Copy rest of the code
COPY . .
# Step 5.1: Copy the entire .env file
COPY .env .env
# Step 5.2: Build
RUN npm run build


# Stage 2: Run the app
# Step 1: Use light version of the node image
FROM node:20-alpine AS runtime
# Step 2: Set working directory inside the container
WORKDIR /app
# Step 3: Copy package json files in folder
COPY package*.json ./
# Step 4: Install only production dependencies not dev-dependency
RUN npm install --only=production -g serve
# Step 5: Copy build files from build stage to runtime stage
COPY --from=build /app/dist ./dist
# Step 6: Run container on the given port
EXPOSE 3000
# Step 7: Run commane to run the application on mentioned port
# CMD ["npm", "run", "preview", "--", "--host", "--port", "3030"]
CMD ["serve", "-s", "dist", "-l", "3000"]