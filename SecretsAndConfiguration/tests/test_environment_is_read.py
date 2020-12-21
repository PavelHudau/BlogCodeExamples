import src.simple_app as simple_app


def test_db_username_is_present():
    assert simple_app.Environment.db_user_name()


def test_db_password_is_present():
    assert simple_app.Environment.db_password()


def test_db_server_is_present():
    assert simple_app.Environment.db_server()


def test_db_server_port_is_present():
    assert simple_app.Environment.db_server_port()
