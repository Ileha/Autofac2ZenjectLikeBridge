---
layout: default
title: ZenAutofac
---

<!-- This page reuses the repository README as the site homepage -->
{% capture readme_raw %}{% include_relative README.md %}{% endcapture %}
{{ readme_raw | markdownify }}
