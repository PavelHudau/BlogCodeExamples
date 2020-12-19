#!/bin/bash

set -e

SECRETS_FILE="../data/secrets.txt"
CONFIGS_FILE="../data/configs.txt"

read_config_from_file() {
    [[ "$#" -eq 1 ]] || {
        echo "1 arguments required (config name), $# provided." >&2
        exit 1
    }

    CONFIG_NAME=$1
    CONFIG_PATTERN="$CONFIG_NAME="
    echo $(grep $CONFIG_PATTERN $CONFIGS_FILE | sed -e "s/^$CONFIG_PATTERN//")
}

read_secret_from_file() {
    [[ "$#" -eq 1 ]] || {
        echo "1 arguments required (secret name), $# provided." >&2
        exit 1
    }

    SECRET_NAME=$1
    SECRET_PATTERN="$SECRET_NAME="
    echo $(grep $SECRET_PATTERN $SECRETS_FILE | sed -e "s/^$SECRET_PATTERN//")
}