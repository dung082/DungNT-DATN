import {
  HomeOutlined,
  LogoutOutlined,
  ReadOutlined,
  SoundOutlined,
  UserOutlined,
} from "@ant-design/icons";
import { Dropdown, Layout, Menu, Space } from "antd";
import { Footer } from "antd/es/layout/layout";
import { useState } from "react";
import { Outlet, useNavigate } from "react-router-dom";
const { Header, Sider, Content } = Layout;
export default function PageTemplate() {
  const navigate = useNavigate();
  const handleMenuClick = (e) => {
    if (e.key === "1") {
      navigate("/Info");
    } else if (e.key === "2") {
      logout();
    }
  };

  const logout = () => {
    console.log("1");
    sessionStorage.removeItem("userInfo");
    navigate("/Login");
  };
  const items = [
    {
      key: "1",
      label: "Thông tin cá nhân",
      icons: <UserOutlined />,
      onclick: () => {
        navigate("/Info");
      },
    },
    {
      key: "2",
      label: "Đăng xuất",
      icons: <LogoutOutlined />,
      onclick: logout,
    },
  ];
  const [collapsed, setCollapsed] = useState(false);
  // const { Search } = Input;
  return (
    <>
      <div className="h-screen w-screen">
        <Layout className="h-full">
          <Sider
            trigger={null}
            collapsible
            collapsed={collapsed}
            className="sider"
          >
            <div
              className={
                collapsed
                  ? "logo-menu h-[60px] flex items-center justify-center "
                  : "logo-menu h-[60px] flex items-center justify-center"
              }
            >
              {collapsed ? (
                <button
                  onClick={() => {
                    setCollapsed(!collapsed);
                  }}
                >
                  <span className="material-icons text-white md-36">
                    chevron_left
                  </span>
                </button>
              ) : (
                <button
                  onClick={() => {
                    setCollapsed(!collapsed);
                  }}
                >
                  {" "}
                  <span className="material-icons text-white md-36">
                    chevron_right
                  </span>
                </button>
              )}
            </div>
            <Menu
              mode="inline"
              selectedKeys={
                window.location.pathname === "/"
                  ? "Home"
                  : window.location.pathname
              }
              // defaultSelectedKeys={["1"]}
              items={[
                {
                  key: "/Home",
                  label: "Trang chủ",
                  icon: <HomeOutlined />,
                  onClick: () => {
                    navigate("/Home");
                  },
                },
                {
                  key: "sub2",
                  label: "Thông tin chung",
                  icon: <UserOutlined />,
                  children: [
                    {
                      key: "/Info",
                      label: "Thông tin cá nhân",
                      onClick: () => {
                        navigate("/Info");
                      },
                    },
                    {
                      key: "/ChangePassword",
                      label: "Đổi mật khẩu",
                      onClick: () => {
                        navigate("/ChangePassword");
                      },
                    },
                  ],
                },
                {
                  key: "sub3",
                  label: "Học tập",
                  icon: <ReadOutlined />,
                  children: [
                    { key: "7", label: "Thời khóa biểu" },
                    { key: "8", label: "Chương trình khung" },
                  ],
                },
                {
                  key: "sub4",
                  label: "Thông báo",
                  icon: <SoundOutlined />,
                },
              ]}
            />
          </Sider>
          <Layout className="bg-[#d7d6d6]">
            <Header className="h-[60px] bg-white flex justify-end ">
              <div>
                <Dropdown
                  menu={{
                    items,
                    onClick: handleMenuClick,
                  }}
                >
                  <a>
                    <Space>Xin chào ...</Space>
                  </a>
                </Dropdown>
              </div>
            </Header>
            <Content className="min-h-[300px]  p-8">
              <div
                className="bg-white rounded-md w-full h-full"
                style={{ background: "#fff" }}
              >
                <Outlet />
              </div>
            </Content>
            <Footer className="text-center">
              Một sản phẩm của Nguyễn Tiến Dũng
            </Footer>
          </Layout>
        </Layout>
      </div>
    </>
  );
}
