Invoke-WebRequest http://localhost:5218/swagger/v1/swagger.yaml -OutFile docs//swagger.yml
npx @openapitools/openapi-generator-cli generate `
  -i docs//swagger.yml `
  -g typescript-fetch `
  -o src//ClientApp//src//infrastructures//typescript-fetch `
  --additional-properties=modelPropertyNaming=camelCase,supportsES6=true,typescriptThreePlus=true
