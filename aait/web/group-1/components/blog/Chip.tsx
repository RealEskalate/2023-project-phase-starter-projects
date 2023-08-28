import React from 'react'

interface ChipProps {
    tag: string;
    isSelected: boolean;
    onClick: (tag: string) => void;
  }
  
  const Chip: React.FC<ChipProps> = ({ tag, isSelected, onClick }) => (
    <div
      onClick={() => onClick(tag)}
      className={`px-3 py-1 font-semibold text-sm rounded-full cursor-pointer ${
        isSelected
          ? "border border-primary-color text-primary-color"
          : "border-none text-add-blog-chip-color"
      }`}
    >
      {tag}
    </div>
  );

export default Chip
