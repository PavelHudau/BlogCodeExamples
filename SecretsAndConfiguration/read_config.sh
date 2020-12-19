#!/bin/bash

set -e

[[ "$#" -eq 1 ]] || {
    echo "1 arguments required (config name), $# provided." >&2
    exit 1
}

WORKING_DIR="$(dirname "${BASH_SOURCE[0]}")"
CONFIGS_FILE="$WORKING_DIR/data/configs.txt"
CONFIG_NAME=$1
CONFIG_PATTERN="$CONFIG_NAME="
echo $(grep $CONFIG_PATTERN $CONFIGS_FILE | sed -e "s/^$CONFIG_PATTERN//")