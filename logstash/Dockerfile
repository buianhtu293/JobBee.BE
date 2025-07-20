FROM docker.elastic.co/logstash/logstash:9.0.1
RUN bin/logstash-plugin install logstash-output-opensearch
COPY logstash.conf /usr/share/logstash/pipeline/logstash.conf
