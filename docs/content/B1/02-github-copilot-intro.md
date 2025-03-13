# GitHub Copilot Introduction

- What is GitHub Copilot
- Architecture

---

# What is [GitHub Copilot](https://github.com/features/copilot)?

<div style="width: 30%; float: right">
  <img src="images/github-copilot.svg">
</div>

*An integration of LLMs for code generation*

<div style="width: 60%; float: right">

- Multiple features as extensions: 
  - GitHub Copilot (Intellisense)
  - GitHub Copilot Chat (IDE & GitHub.com)
  - GitHub Copilot in the CLI
- Ecosystem around
  - Copilot Extensions
  - GitHub Workspace  
- Based on [OpenAI](https://platform.openai.com/docs/models/overview) GPT models. 
- Anthropic Claude & Google Gemini is in preview.

</div>
---

# GitHub Copilot Architecture

---


# GitHub Copilot Chat

![drop-shadow bg width: 75%](images/life-of-a-completion/life-of-a-chat-completion-high-level.drawio.svg)


---

# LLM - Prompt Completion

![image](/images/prompt-engineering-language-model.jpg) <!-- .element style="float: right" width="50%"-->

*Stateless by design*

- Prompt - input
  - User prompt - question
  - System prompt - instructions
  - Settings
- Completion - output
  - Response messages


---

# GitHub Copilot Chat -  Request

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
      "role": "user", "content": "could you fix the function fizbuzz"      
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

# GitHub Copilot Chat - */Explain*



<div style="width: 90%; margin: auto">

```json
"messages": [
  {
    "content": "You are a world-class coding tutor. 
                Your code explanations perfectly balance high-level concepts and granular details. 
                Your approach ensures that students not only understand how to write code, 
                but also grasp the underlying principles that guide effective programming.
                ....
                Additional Rules
                Think step by step:
                1. Examine the provided code selection and any other context like user question, related errors, project details, class definitions, etc.
                2. If you are unsure about the code, concepts, or the user's question, ask clarifying questions.
                3. If the user provided a specific question or error, answer it based on the selected code and additional provided context. 
                    Otherwise focus on explaining the selected code.
                4. Provide suggestions if you see opportunities to improve code readability, performance, etc.
                ....
                Focus on being clear, helpful, and thorough without assuming extensive prior knowledge.
                Use developer-friendly terms and analogies in your explanations.
                Use Markdown formatting in your answers. When suggesting code changes, use Markdown code blocks.",
    "role": "system"
  },
  {
      "role": "user",
      "content": "Active selection:
                  From the file: calculator.py
                  ```python
                  def calculator():\n
                      print(\"Enter two numbers:\")\n
                  ```"
  },
      {
          "role": "user", "content": "Write an explanation for the code above as paragraphs of text."
      }
]
```
</div>
---

# GitHub Copilot Chat - */Fix*



<div style="width: 90%; margin: auto">

```json
"messages": [
  {
    "content": "You specialize in being a highly skilled code generator. 
                Your task is to help the Developer fix an issue.
                If context is provided, try to match the style of the provided code 
                as best as possible.
                Generated code is readable and properly indented.
                Markdown blocks are used to denote code.
                Preserve user's code comment blocks, do not exclude them when refactoring code.
                Pay especially close attention to the selection or exception context.
                Given a description of what to do you can refactor, fix or enhance the existing code.
                ....",
    "role": "system"
  },
  {
      "role": "user",
      "content": "# FILE:CALCULATOR.PY CONTEXT
                  User's current visible code:
                  Excerpt from calculator.py, lines 1 to 2:
                  ```python
                  def calculator():\n
                      print(\"Enter two numbers:\")\n
                  ```"
  },
      {
          "role": "user", "content": "There is a problem in this code. Rewrite the code to show it with the bug fixed."
      }
]
```
</div>
---

# GitHub Copilot Inline

![drop-shadow bg width: 75%](images/life-of-a-completion/life-of-a-completion-high-level.drawio.svg)


---

# GitHub Copilot Inline - Request

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

![drop-shadow bg width: 75%](images/life-of-a-completion/life-of-a-completion-high-level-2.drawio.svg)

---

# GitHub Copilot Inline

![drop-shadow bg width: 75%](images/life-of-a-completion/life-of-a-completion-high-level-3.drawio.svg)

---

# GitHub Copilot Inline

![drop-shadow bg width: 75%](images/life-of-a-completion/life-of-a-completion-high-level-4.drawio.svg)

<!-- Note:
Prompt generation - 
A series of algorithms first select relevant code snippets or comments from your current file and other sources. These snippets and comments are then prioritized, filtered, and assembled into the final prompt.

Prompt library - 
The prompt tells LLMs, including GitHub Copilot, what data, and in what order, to process in order to contextualize the code. Most of this work takes place in a prompt library, which is where GitHubs in-house ML experts work with algorithms to extract and prioritize a variety of sources of information about the developer’s context, creating the prompt that’ll be processed by the GitHub Copilot model

Vector database - 
A database that indexes high-dimensional vectors - mathematical representations of objects. When used to represent pieces of code, they may represent both the semantics and intention of the code—not just the syntax - referred to as embeddings.

Embeddings - 
In the context of coding and LLMs, an embedding is the representation of a piece of code as a high-dimensional vector. Algorithms would create embeddings for all snippets in the repository (potentially billions of them), and keep them stored in the vector database.

How it works - 
Algorithms would make approximate matches in real time, between the embeddings that are created for the IDE snippets and the embeddings already stored in the vector database. The vector database is what allows algorithms to quickly search for approximate matches (not just exact ones) on the vectors it stores, even if it’s storing billions of embedded code snippets
-->

---

# Models used by GitHub Copilot

* GitHub Copilot (June 2022)
  - Based on GPT-3 Codex, GPT-4o-mini is in preview
  - Trained with supervised fine-tuning on open source code
  - Has been updated with new features
    - Fill-In-the-Middle, User Context and Filter System
  - Optimized for speed
* GitHub Copilot Chat (Dec 2023)
  - Uses GPT-4o for prompt completions
  - Uses GPT-3.5 Turbo for generating context questions
  - Preview of Claude 3.5/3.7 Sonnet, o1 and o1-mini, and Gemini 2.0 Flash
  - Is designed to only respond to coding related questions

<!-- Note:

Supervised fine-tuning - 
Involves adjusting the weights and biases of a pre-trained model using a smaller set of labeled data, thereby customizing the model for specific downstream tasks

Fill-In-the-Middle - 
Instead of only considering the prefix of the code, it also leverages known code suffixes and leaves a gap in the middle for GitHub Copilot to fill. This way, it now has more context about your intended code and how it should align with the rest of your program

User context - 
GitHub Copilot now uses basic information about the user’s context—for example, whether the last suggestion was accepted—to reduce the frequency of unwanted suggestions

Filter System - 
AI-based vulnerability prevention system that blocks insecure coding patterns in real-time to make GitHub Copilot suggestions more secure. The model targets the most common vulnerable coding patterns, including hardcoded credentials, SQL injections, and path injections.
-->

---
# Model Context Window - [Token Size](https://platform.openai.com/tokenizer)


- Context window management can be implemented in may ways.

- Token truncation is mostly used where you either cut off the beginning or end (FIFO or FILO)


<div style="width: 55%; float: left">


| Model 	                 | Description 	    | Context Window (tokens) |
|--------------------------|------------------|-------------------------|
| GPT-3.5 Turbo (0125)     | Released Jan 24  | 16k / 4k                |
| GPT-4o (2024-05-13)      | Multimodal       | 128k / 16k              |
| GPT-4o-mini (2024-07-18) | Multimodal       | 128k / 16k              |
| GPT o1-mini (2024-09-12) | Reasoning        | 128k / 64k              |
| GPT o1 (2024-12-17)      | Reasoning        | 200k / 100k             |
| GPT o3-mini (2025-01-31) | Reasoning        | 200k / 100k             |
| GitHub Copilot Codex     | GPT-3 based      | ?      	                |
| GitHub Copilot Chat	     | GPT-4o-mini      | 128k / 16k      	      |
| GitHub Copilot Chat	     | GPT-4o           | ?      	                |

</div>

<div style="width: 45%; float: right">

  <img src="images/context.drawio.svg">
</div>
