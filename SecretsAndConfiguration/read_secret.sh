#!/bin/bash

set -e

[[ "$#" -eq 1 ]] || {
    echo "1 arguments required (secret name), $# provided." >&2
    exit 1
}

WORKING_DIR="$(dirname "${BASH_SOURCE[0]}")"
SECRETS_FILE="$WORKING_DIR/data/secrets.txt"
SECRET_NAME=$1
SECRET_PATTERN="$SECRET_NAME="
echo $(grep $SECRET_PATTERN $SECRETS_FILE | sed -e "s/^$SECRET_PATTERN//")