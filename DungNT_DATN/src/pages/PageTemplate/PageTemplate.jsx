import { Menu } from "antd";

export default function PageTemplate() {
  const items = [
    {
      label: "Trang chu",
      key: "home",
    },
    {
      label: "Thong tin chung",
      key: "info",
    },
    {
      label: "Hoc tap",
      key: "study",
    },
    {
      label: "Thong bao",
      key: "notice",
      children: [
        {
          label: "Hoc tap",
          key: "z",
        },
      ],
    },
  ];

  return (
    <>
      <div className="h-screen w-screen">
        <div className="" style={{ borderBottom: "1px solid #e9e6e6" }}>
          <div className="w-[1200px] m-auto min-h-[70px] flex justify-between items-center ">
            <div className="flex items-center">
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
      </div>
    </>
  );
}
