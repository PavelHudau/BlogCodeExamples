#!/bin/bash

WORKING_DIR="$(dirname "${BASH_SOURCE[0]}")"

read_secret="$WORKING_DIR/../read_secret.sh"
read_config="$WORKING_DIR/../read_config.sh"

DB_USERNAME=$($read_secret db_username) \
DB_PASSWORD=$($read_secret db_password) \
DB_SERVER=$($read_config db_server) \
DB_SERVER_PORT=$($read_config db_server_port) \
python3.7 $WORKING_DIR/simple_app.py  "$@"