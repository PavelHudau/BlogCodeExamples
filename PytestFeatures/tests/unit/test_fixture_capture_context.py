import pytest

MODULE_VARIABLE = "MODULE_VARIABLE value"


@pytest.fixture
def awesome_fixture(request):
    print("function_fixture setup, running from")
    print(f"Module: '{request.module.__name__}''")
    print(f"Function: '{request.function.__name__}''")
    print(f"Module variable: {request.module.MODULE_VARIABLE}")

    print(f"SETUP")
    yield
    print("TEARDOWN")

# Run as
# pytest -v -s tests/unit/test_fixture_scope.py
def test_fixture_context(awesome_fixture):
    print(f"RUNNING : {__name__}")
    # Make test fail to see the output
    assert True
