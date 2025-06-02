# JobBee.BE

## Step by step to run Kibana
### Step 1: Open terminal and run this command
```cmd
docker exec -it els bin/elasticsearch-service-tokens create elastic/kibana kibana-token
```
### Step 2: Copy token to ELASTICSEARCH_SERVICEACCOUNTTOKEN in yml
```cmd
ELASTICSEARCH_SERVICEACCOUNTTOKEN=your_token
```

### Step 3: Please run docker compose again