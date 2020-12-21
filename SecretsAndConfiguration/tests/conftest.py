import os
import subprocess

import pytest

ENVIRONMENT_READ_TOOLS_PATH = "."


@pytest.fixture(scope="session", autouse=True)
def test_env():
    os.environ["DB_USERNAME"] = _read_secret("db_username")
    os.environ["DB_PASSWORD"] = _read_secret("db_password")
    os.environ["DB_SERVER"] = _read_config("db_server")
    os.environ["DB_SERVER_PORT"] = _read_config("db_server_port")


def _read_secret(secret_name: str) -> str:
    result = subprocess.run(
        [f"{ENVIRONMENT_READ_TOOLS_PATH}/read_secret.sh", secret_name],
        stdout=subprocess.PIPE)
    secret = result.stdout.decode('utf-8')
    return str.strip(secret)


def _read_config(config_name: str) -> str:
    result = subprocess.run(
        [f"{ENVIRONMENT_READ_TOOLS_PATH}/read_config.sh", config_name],
        stdout=subprocess.PIPE)
    config = result.stdout.decode('utf-8')
    return str.strip(config)
