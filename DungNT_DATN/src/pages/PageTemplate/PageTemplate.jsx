import { Menu } from "antd";

export default function PageTemplate() {
  const items = [
    {
      label: "Trang chủ",
      key: "home",
    },
    {
      label: "Thông tin chung",
      key: "info",
      children: [
        {
          label: "Thông tin cá nhân",
          key: "infomation",
        },
      ],
    },
    {
      label: "Học tập",
      key: "study",
      children: [
        {
          label: "Thời khóa biểu",
          key: "sheet",
        },
      ],
    },
    {
      label: "Thông báo",
      key: "notice",
    },
  ];
  // const { Search } = Input;
  return (
    <>
      <div className="h-screen w-screen">
        <div className="" style={{ borderBottom: "1px solid #e9e6e6" }}>
          <div className="w-[1300px] m-auto min-h-[60px] flex justify-between items-center ">
            <div className="flex items-center">
              <div className="flex items-center cursor-pointer">
                <div>
                  <span className="material-icons" style={{ fontSize: 60 }}>
                    school
                  </span>
                </div>
                <div className="ml-2">
                  <div className="text-xl">TRƯỜNG THCS HÒA BÌNH</div>
                  <div>HOA BINH SECONDARY SCHOOL</div>
                </div>
              </div>
              {/* <div>
                <Search
                  placeholder="input search text"
                  className="ml-4"
                  // onSearch={onSearch}
                  style={{
                    width: 400,
                  }}
                />
              </div> */}
            </div>
            <div className="flex items-center">
              <div>
                <Menu
                  mode="horizontal"
                  className="p-0 border-none "
                  items={items}
                />
              </div>
              <div className="cursor-pointer ml-2">Chào mừng</div>
            </div>
          </div>
        </div>

        <div className="bg-[#f0f2f5] pt-5" style={{height : "calc(100vh - 155px"}}>
          <div className="w-[1300px] m-auto min-h-[600px] bg-white rounded-md">
              
          </div>
        </div>

        <div className="text-center py-[30px] px-[70px]">
              Một sản phẩm của DungNT
        </div>
      </div>
    </>
  );
}
