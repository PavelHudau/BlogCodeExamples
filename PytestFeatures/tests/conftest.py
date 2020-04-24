import pytest


@pytest.fixture(scope="session")
def session_fixture():
    print("session_fixture setup")
    yield
    print("session_fixture teardown")


@pytest.fixture(scope="module")
def module_fixture():
    print(f"module_fixture setup")
    yield
    print(f"module_fixture teardown")


@pytest.fixture
def explicit_fixture():
    print("explicit_fixture setup")
    yield
    print("explicit_fixture teardown")
