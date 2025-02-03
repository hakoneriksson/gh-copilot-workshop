# GitHub Copilot Introduction

- What is GitHub Copilot
- Quick look in IDE
- Architecture
  - Models Used
  - Prompt Completion Pipeline
  - Context Limitations

---

# What is [GitHub Copilot](https://github.com/features/copilot)?
![image](images/github-copilot.svg) <!-- .element style="float: right" width="40%"-->


*An integration of LLMs for code generation*

- Multiple features: 
  - GitHub Copilot (Intellisense)
  - GitHub Copilot Chat (IDE & GitHub.com)
  - GitHub Copilot in the CLI
- Ecosystem around
  - Copilot Extensions
  - GitHub Workspace
  
- Based on [OpenAI](https://platform.openai.com/docs/models/overview) GPT models. Claude Sonnet is in preview.

---

# GitHub Copilot in Visual Studio Code

![image](images/vs-code-github-copilot.png)  <!-- .element width="80%"-->

---

# GitHub Copilot Architecture

---

# Models used by GitHub Copilot

* GitHub Copilot (June 2022)
  - Based on GPT-3 Codex
  - Trained with supervised fine-tuning on open source code
  - Has been updated with new features
    - Fill-In-the-Middle, User Context and Filter System
  - Optimized for speed
* GitHub Copilot Chat (Dec 2023)
  - Uses GPT-4o for prompt completions
  - Uses GPT-3.5 Turbo for generating context questions
  - Preview of Claude 3.5 Sonnet, o1 and o1-mini
  - Is designed to only respond to coding related questions


---

# Understanding Prompt Completion Pipeline

![image](images/prompt-engineering-language-model.jpg) <!-- .element style="float: right" width="50%"-->

*Stateless by design*

- Prompt - input
  - User prompt
  - System prompt
  - Settings
- Completion - output
  - Response messages


---

# GitHub Copilot Chat

![drop-shadow bg width: 75%](images/life-of-a-chat-completion-high-level.drawio.svg)


---

# GitHub Copilot Chat IDE Request

<div style="width: 35%; float: left">
  <img src="images/fizzbuzz.png">
</div>

<div style="width: 65%; float: right">

```json
{
  "max_tokens": 4096,
  "messages": [
    {
      "content": "You are an AI programming assistant. When asked for your name, you must respond with \"GitHub Copilot\". 
                  Follow the user's requirements carefully & to the letter. 
                  Your expertise is strictly limited to software development topics.
                  ....
                  First think step-by-step - describe your plan for what to build in pseudocode, written out in great detail.
                  Then output the code in a single code block.
                  ....
                  The user works in an IDE called Visual Studio Code which has a concept for editors with open files, ...
                  The user is working on a Windows machine. Please respond with system specific commands if applicable.
                  The active document is the source code the user is looking at right now.",
      "role": "system"
    },
    {
      "content": "Excerpt from active file fizzbuzz.js, lines 1 to 14:
                  ```javascript 
                  function fizzbuzz() 
                  ....
                  ``` ...
                  The cursor is on line: 13",
      "role": "user"
    },
    {
      "content": "could you fix the function fizbuzz",
      "role": "user"
    }
  ],
  "model": "gpt-4o",
  "stream": true,
  "temperature": 0.1
}
```

</div>

<!-- Note:
System prompt:

You are an AI programming assistant.
When asked for your name, you must respond with \"GitHub Copilot\".
Follow the user's requirements carefully & to the letter.
Your expertise is strictly limited to software development topics.
Follow Microsoft content policies.
Avoid content that violates copyrights.
For questions not related to software development, simply give a reminder that you are an AI programming assistant.
Keep your answers short and impersonal.
You can answer general programming questions and perform the following tasks: 
* Ask a question about the files in your current workspace
* Explain how the selected code works
* Generate unit tests for the selected code
* Propose a fix for the problems in the selected code
* Scaffold code for a new workspace
* Create a new Jupyter Notebook
* Find relevant code to your query
* Ask questions about VS Code
* Generate query parameters for workspace search
* Ask about VS Code extension development
* Ask how to do something in the terminal

You use the GPT-4 version of OpenAI's GPT models.
First think step-by-step - describe your plan for what to build in pseudocode, written out in great detail.
Then output the code in a single code block.
Minimize any other prose.
Use Markdown formatting in your answers.
Make sure to include the programming language name at the start of the Markdown code blocks.
Avoid wrapping the whole response in triple backticks.
The user works in an IDE called Visual Studio Code which has a concept for editors with open files, integrated unit test support, an output pane that shows the output of running the code as well as an integrated terminal.
The user is working on a Windows machine. Please respond with system specific commands if applicable.
The active document is the source code the user is looking at right now.
You can only give one reply for each conversation turn.
-->

---

# GitHub Copilot Inline

![drop-shadow bg width: 75%](images/life-of-a-completion-high-level.drawio.svg)


---

# GitHub Copilot Inline IDE request

<div style="width: 51%; float: left">
  <img src="images/calculator-py.png">
</div>

<div style="width: 49%; float: right">

```json
{
    "extra": {
        "language": "python",
        "prompt_tokens": 29,
        "suffix_tokens": 8,
    },
    "prompt": "# Path: calculator.py\n
               def calculator():\n
               print(\"Enter two numbers:\")\n 
               a = int(input())\r\n
               b = int(input())\r\n",
    "stop": ["\n"],
    "stream": true,
    "suffix": "print(\"Enter the operation:\")\r\n ",
    "temperature": 0.2,
    "top_p": 1
}
```

</div>

---

# GitHub Copilot Inline

![drop-shadow bg width: 75%](images/life-of-a-completion.drawio.svg)


---

# More resources

- [Intro to LLMs, Andrej Karpathy](https://youtu.be/zjkBMFhNj_g)
- [A developer's guide to prompt engineering and LLMs](https://github.blog/2023-07-17-prompt-engineering-guide-generative-ai-llms/)
- [GitHub Copilot Documentation](https://copilot.github.com/)
- [GitHub Copilot: An AI Pair Programmer](https://github.blog/2021-06-29-introducing-github-copilot-ai-pair-programmer/)
- [Tim Warners resources](https://github.com/timothywarner/copilot-dev)

---

# Studies

- [Coding on Copilot: 2023 Data Suggests Downward Pressure on Code Quality](https://www.gitclear.com/coding_on_copilot_data_shows_ais_downward_pressure_on_code_quality)
- [Exploring the Verifiability of Code Generated by GitHub Copilot](https://ar5iv.labs.arxiv.org/html/2209.01766v2)