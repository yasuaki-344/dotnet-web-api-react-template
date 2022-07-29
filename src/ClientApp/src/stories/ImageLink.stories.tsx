import React from "react";
import { ComponentStory, ComponentMeta } from "@storybook/react";

import { ImageLink } from "../components/ui-parts";

// More on default export: https://storybook.js.org/docs/react/writing-stories/introduction#default-export
export default {
  title: "ImageLink",
  component: ImageLink,
  // More on argTypes: https://storybook.js.org/docs/react/api/argtypes
  argTypes: {
    backgroundColor: { control: "color" },
  },
} as ComponentMeta<typeof ImageLink>;

// More on component templates: https://storybook.js.org/docs/react/writing-stories/introduction#using-args
const Template: ComponentStory<typeof ImageLink> = (args) => (
  <ImageLink {...args} />
);

export const Vite = Template.bind({});
// More on args: https://storybook.js.org/docs/react/writing-stories/args
Vite.args = {
  href: "https://vitejs.dev",
  src: "/vite.svg",
  className: "logo",
  alt: "Vite logo",
};
