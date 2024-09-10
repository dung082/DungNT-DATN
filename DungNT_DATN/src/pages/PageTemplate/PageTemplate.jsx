import {
  HomeOutlined,
  LogoutOutlined,
  ReadOutlined,
  SoundOutlined,
  UserOutlined,
} from "@ant-design/icons";
import { Avatar, Dropdown, Layout, Menu, Space } from "antd";
import { Footer } from "antd/es/layout/layout";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Outlet, useNavigate } from "react-router-dom";
import { globalState } from "../../reducers/globalReducer/globalReducer";
import ThongBao from "../PageContent/ThongBao/ThongBao";
import { getListThongBaoAction } from "../../reducers/thongBaoReducer/thongBaoReducer";
const { Header, Sider, Content } = Layout;
export default function PageTemplate() {
  const navigate = useNavigate();
  const { userInfo } = useSelector(globalState);
  const dispatch = useDispatch();
  useEffect(() => {
    if (!userInfo) {
      // if (!sessionStorage.getItem("userInfo")) {
      navigate("/Login");
      // }
    }
    else {
      dispatch(getListThongBaoAction(userInfo?.username));
    }
  }, []);

  const handleMenuClick = (e) => {
    if (e.key === "1") {
      navigate("/ThongTinCaNhan");
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
      onClick: () => {
        navigate("/ThongTinCaNhan");
      },
    },
    {
      key: "2",
      label: "Đăng xuất",
      icons: <LogoutOutlined />,
      onClick: logout,
    },
  ];
  const [collapsed, setCollapsed] = useState(false);
  // const { Search } = Input;
  return (
    <>
      <div className="w-screen h-screen ">
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
                  : "logo-menu h-[60px] flex items-center justify-between"
              }
            >
              <div className={collapsed ? "" : "bg-logo-menu"}></div>
              <div>
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
            </div>
            <Menu
              mode="inline"
              selectedKeys={
                window.location.pathname === "/"
                  ? "/TrangChu"
                  : window.location.pathname
              }
              // defaultSelectedKeys={["1"]}
              items={userInfo?.userType === 2 ? [
                {
                  key: "/TrangChu",
                  label: "Trang chủ",
                  icon: <HomeOutlined />,
                  onClick: () => {
                    navigate("/TrangChu");
                  },
                },
                {
                  key: "/ThongTinCaNhan",
                  label: "Thông tin cá nhân",
                  onClick: () => {
                    navigate("/ThongTinCaNhan");
                  },
                  icon: <UserOutlined />,
                },
                {
                  key: "sub3",
                  label: "Học tập",
                  icon: <ReadOutlined />,
                  children: [
                    {
                      key: "/ChuongTrinhHoc",
                      label: "Chương trình học",
                      onClick: () => {
                        navigate("/ChuongTrinhHoc");
                      },
                    },
                    // {
                    //   key: "/ThongTinHocBa",
                    //   label: "Học bạ",
                    //   onClick: () => {
                    //     navigate("/ThongTinHocBa");
                    //   },
                    // },
                    {
                      key: "/DanhSachHocSinh",
                      label: "Danh sách học sinh",
                      onClick: () => {
                        navigate("/DanhSachHocSinh");
                      },
                    },
                    {
                      key: "/ThoiKhoaBieu",
                      label: "Thời khóa biểu",
                      onClick: () => {
                        navigate("/ThoiKhoaBieu");
                      },
                    },
                    {
                      key: "/LichThi",
                      label: "Lịch thi",
                      onClick: () => {
                        navigate("/LichThi");
                      },
                    },
                    {
                      key: "/DiemDanh",
                      label: "Điểm danh, xin nghỉ",
                      onClick: () => {
                        navigate("/DiemDanh");
                      },
                    },
                    {
                      key: "/DiemThi",
                      label: "Điểm thi",
                      onClick: () => {
                        navigate("/DiemThi");
                      },
                    },
                    {
                      key: "/DiemTongKet",
                      label: "Điểm tổng kết",
                      onClick: () => {
                        navigate("/DiemTongKet");
                      },
                    },
                  ],
                },
                // {
                //   key: "sub4",
                //   label: "Thông báo",
                //   icon: <SoundOutlined />,
                // },
              ] : [
                {
                  key: "/TrangChu",
                  label: "Trang chủ",
                  icon: <HomeOutlined />,
                  onClick: () => {
                    navigate("/TrangChu");
                  },
                },
                {
                  key: "/ThongTinCaNhan",
                  label: "Thông tin cá nhân",
                  onClick: () => {
                    navigate("/ThongTinCaNhan");
                  },
                  icon: <UserOutlined />,
                },

                {
                  key: "/QuanLyHocSinh",
                  label: "Quản lý học sinh",
                  onClick: () => {
                    navigate("/QuanLyHocSinh");
                  },
                  icon: <span className="material-icons">
                    people
                  </span>
                },

                {
                  key: "/DiemDanhHS",
                  label: "Điểm danh học sinh",
                  onClick: () => {
                    navigate("/DiemDanhHS");
                  },
                  icon: <span className="material-icons">
                    fact_check
                  </span>
                },
              ]}
            />
          </Sider>
          <Layout className="bg-[#d7d6d6]">
            <Header className="h-[60px] bg-white flex justify-end items-center">
              <div className="flex items-center">

                <ThongBao />
                <Dropdown
                  menu={{
                    items,
                    onClick: handleMenuClick,
                  }}
                >
                  <a>
                    <Space>
                      <div className="flex items-center ml-2">
                        <div>
                          <Avatar
                            size={40}
                            src={
                              <img
                                src={userInfo?.avatar
                                }
                                alt="avatar"
                              />
                            }
                          />
                        </div>
                        <div className="ml-2">
                          <div>Xin chào </div>
                          <div className="font-bold">{userInfo?.username}</div>
                        </div>
                      </div>
                    </Space>
                  </a>
                </Dropdown>
              </div>
            </Header>
            <Content className="min-h-[300px] p-8 overflow-auto">
              <div
                className="bg-white rounded-md w-full h-full overflow-auto"
                style={{ background: "#fff" }}
              >
                <Outlet />
              </div>
            </Content>
            <Footer className="text-center">
              Trường THPT Hòa Bình
            </Footer>
          </Layout>
        </Layout>
      </div>
    </>
  );
}
